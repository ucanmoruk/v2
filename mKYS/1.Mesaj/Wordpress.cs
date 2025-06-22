using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using mKYS;

namespace mROOT._1.Mesaj
{
    public partial class Wordpress : Form
    {

        private static readonly HttpClient client = new HttpClient { Timeout = TimeSpan.FromMinutes(2) };
        private List<BlogSite> blogSites = new List<BlogSite>();
        private List<TermItem> categories = new List<TermItem>();
        private bool isLoadingCategories = false; // Kategori yüklenirken tekrar tetiklenmesini önlemek için.
        sqlbaglanti bgl = new sqlbaglanti();
        BlogListe m = (BlogListe)System.Windows.Forms.Application.OpenForms["BlogListe"];

        public Wordpress()
        {
            InitializeComponent();
        }

        public class BlogSite
        {
            public string Name { get; set; }
            public string ApiUrl { get; set; }
            public string Username { get; set; }
            public string AppPassword { get; set; }
        }

        public class TermItem
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public static string gelis, durum;
        public static int bID;
        private void Wordpress_Load(object sender, EventArgs e)
        {
            LoadSites();
            csite.SelectedIndexChanged += Csite_SelectedIndexChanged;

            if (durum =="Yayınlandı")
            {
                btn_send.Enabled = false;
            }

            if (gelis=="" || gelis== null)
            {
                
            }
            else
            {
                detaybul(bID);
                btn_save.Text = "Güncelle";

            }

        }

        private async void LoadSites()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bloglar.json");
                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    blogSites = JsonSerializer.Deserialize<List<BlogSite>>(json);

                    csite.Properties.Items.Clear();
                    foreach (var site in blogSites)
                    {
                        csite.Properties.Items.Add(site.Name);
                    }
                }
                else
                {
                    MessageBox.Show("bloglar.json dosyası bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Site bilgileri yüklenemedi: " + ex.Message);
            }
        }

        private async void Csite_SelectedIndexChanged(object sender, EventArgs e)
        {
            //await LoadCategoriesForSelectedSite();
            if (isLoadingCategories) return; // Zaten yükleniyorsa tekrar başlatma

            try
            {
                isLoadingCategories = true;
                await LoadCategoriesForSelectedSite();
            }
            finally
            {
                isLoadingCategories = false;
            }
        }

        //private async Task<int> GetOrCreateTagId(HttpClient client, string baseUrl, string tagName)
        //{
        //    //var tagCheck = await client.GetAsync($"{baseUrl}/tags?search={Uri.EscapeDataString(tagName)}");
        //    //var tagContent = await tagCheck.Content.ReadAsStringAsync();
        //    //var tagResults = JsonSerializer.Deserialize<List<TermItem>>(tagContent);

        //    //if (tagResults != null && tagResults.Count > 0)
        //    //    return tagResults[0].id;

        //    //var newTag = new { name = tagName };
        //    //var tagJson = JsonSerializer.Serialize(newTag);
        //    //var response = await client.PostAsync($"{baseUrl}/tags", new StringContent(tagJson, Encoding.UTF8, "application/json"));
        //    //var result = await response.Content.ReadAsStringAsync();
        //    //var created = JsonSerializer.Deserialize<TermItem>(result);
        //    //return created.id;
        //    var tagCheck = await client.GetAsync($"{baseUrl}/tags?search={Uri.EscapeDataString(tagName)}");
        //    tagCheck.EnsureSuccessStatusCode();
        //    var tagContent = await tagCheck.Content.ReadAsStringAsync();
        //    var tagResults = JsonSerializer.Deserialize<List<TermItem>>(tagContent);

        //    if (tagResults != null && tagResults.Any())
        //        return tagResults[0].id;

        //    var newTag = new { name = tagName };
        //    var tagJson = JsonSerializer.Serialize(newTag);
        //    var response = await client.PostAsync($"{baseUrl}/tags", new StringContent(tagJson, Encoding.UTF8, "application/json"));
        //    response.EnsureSuccessStatusCode();
        //    var result = await response.Content.ReadAsStringAsync();
        //    var created = JsonSerializer.Deserialize<TermItem>(result);
        //    return created.id;
        //}

        //private async Task<int> GetOrCreateTagId(string baseUrl, string tagName)
        //{
        //    // Metot içindeki 'client' kullanımı aynı kalacak, çünkü artık static nesneyi kullanıyor.
        //    var tagCheck = await client.GetAsync($"{baseUrl}/tags?search={Uri.EscapeDataString(tagName)}");
        //    tagCheck.EnsureSuccessStatusCode();
        //    var tagContent = await tagCheck.Content.ReadAsStringAsync();
        //    var tagResults = JsonSerializer.Deserialize<List<TermItem>>(tagContent);

        //    if (tagResults != null && tagResults.Any())
        //        return tagResults[0].id;

        //    var newTag = new { name = tagName };
        //    var tagJson = JsonSerializer.Serialize(newTag);
        //    var response = await client.PostAsync($"{baseUrl}/tags", new StringContent(tagJson, Encoding.UTF8, "application/json"));
        //    response.EnsureSuccessStatusCode();
        //    var result = await response.Content.ReadAsStringAsync();
        //    var created = JsonSerializer.Deserialize<TermItem>(result);
        //    return created.id;
        //}

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gelis != "Güncelle")
            {
                if (kayitdurum != "1")
                {
                    kaydet();
                    
                }
                
            }

           
            // Asıl gönderme işlemini başlat
            await SendPostAsync();

            SqlCommand guncelle = new SqlCommand(@"UPDATE Blog SET 
                    Durum = @a10
                WHERE ID = @id", bgl.baglanti());

            guncelle.Parameters.AddWithValue("@a10", "Yayınlandı"); // Durum alanı sabit veya seçime bağlı olabilir
            guncelle.Parameters.AddWithValue("@id", bID);

            guncelle.ExecuteNonQuery();
            bgl.baglanti().Close();

            if (Application.OpenForms["BlogListe"] == null)
            { }
            else
            {
                m.listele();
            }

            btn_send.Enabled = false;

        }


        private async Task SendPostAsync()
        {
            // --- 1. Girdi Kontrolleri ---
            if (csite.SelectedItem == null)
            {
                MessageBox.Show("Lütfen yayınlanacak siteyi seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tarih.EditValue == null)
            {
                MessageBox.Show("Lütfen yayın tarihini seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbaslik.Text))
            {
                MessageBox.Show("Başlık boş olamaz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 2. Butonları Devre Dışı Bırak ---
            btn_send.Enabled = false;
            btn_save.Enabled = false;

            // --- 3. Değişkenleri Hazırla ---
            string title = tbaslik.Text;
            string content = mmetin.Text;
            string selectedSiteName = csite.SelectedItem.ToString();
            DateTime publishDate = Convert.ToDateTime(tarih.EditValue);
            string selectedCategoryName = ckategori.Text;
            string tags = tanahtar.Text;
            string seoDesc = taciklama.Text;
            string focusKeyword = todak.Text;

            var selectedSite = blogSites.Find(s => s.Name.Equals(selectedSiteName, StringComparison.OrdinalIgnoreCase));
            if (selectedSite == null)
            {
                MessageBox.Show("Seçilen site bilgileri bulunamadı (bloglar.json).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_send.Enabled = true; // Butonları tekrar aktif et
                btn_save.Enabled = true;
                return;
            }

            string imagePathForUpload = null;
            int featuredMediaId = 0;

            try
            {
                // --- 4. Görseli Hazırla ---
                // Önce veritabanından gelen yol (gorselYolu) var mı diye bak
                if (!string.IsNullOrEmpty(gorselYolu) && File.Exists(gorselYolu))
                {
                    imagePathForUpload = gorselYolu;
                }
                // Eğer yoksa, PictureEdit'te yeni bir resim var mı diye bak
                else if (pictureEdit1.Image != null)
                {
                    // Görseli geçici bir dosyaya kaydet
                    imagePathForUpload = Path.Combine(Path.GetTempPath(), $"tempupload_{Guid.NewGuid()}.jpg");
                    using (var bmp = new Bitmap(pictureEdit1.Image))
                    {
                        bmp.Save(imagePathForUpload, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }

                // --- 5. API Kimlik Doğrulama ---
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes($"{selectedSite.Username}:{selectedSite.AppPassword}")));

                // URL'leri daha güvenli bir şekilde oluştur
                var baseUri = new Uri(selectedSite.ApiUrl);
                string rootUrl = baseUri.GetLeftPart(UriPartial.Authority); // "https://orneksite.com"
                string apiBaseUrl = $"{rootUrl}/wp-json/wp/v2";

                // --- 6. Görseli WordPress'e Yükle ---
                if (!string.IsNullOrEmpty(imagePathForUpload))
                {
                    featuredMediaId = await UploadMediaAsync(apiBaseUrl, imagePathForUpload);
                    if (featuredMediaId == 0) return; // Yükleme başarısız olduysa devam etme
                }

                // --- 7. Kategori ve Etiket ID'lerini Al ---
                int? categoryId = categories.FirstOrDefault(c => c.name.Equals(selectedCategoryName, StringComparison.OrdinalIgnoreCase))?.id;
                List<int> tagIds = new List<int>();
                if (!string.IsNullOrWhiteSpace(tags))
                {
                    foreach (var tag in tags.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        int tagId = await GetOrCreateTagId($"{rootUrl}/wp-json", tag.Trim()); // GetOrCreateTagId'ye root API URL'sini gönder
                        if (tagId > 0) tagIds.Add(tagId);
                    }
                }

                // --- 8. Yazı Verisini Oluştur ---
                var postData = new Dictionary<string, object>
        {
            { "title", title },
            { "content", content },
            { "status", publishDate > DateTime.Now ? "future" : "publish" },
            { "date_gmt", publishDate.ToUniversalTime().ToString("o") },
        };
                if (categoryId.HasValue) postData.Add("categories", new int[] { categoryId.Value });
                if (tagIds.Any()) postData.Add("tags", tagIds);
                if (featuredMediaId > 0) postData.Add("featured_media", featuredMediaId);

                // --- 9. Yazıyı Gönder ---
                string json = JsonSerializer.Serialize(postData);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{apiBaseUrl}/posts", httpContent);
                string responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Yazı oluşturulamadı: {response.ReasonPhrase}\n{responseString}", "API Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var createdPost = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(responseString);
                int newPostId = createdPost["id"].GetInt32();
                string postUrl = createdPost["link"].GetString();

                // --- 10. AIOSEO Verilerini Güncelle (Özel Endpoint ile) ---
                if (newPostId > 0 && (!string.IsNullOrWhiteSpace(seoDesc) || !string.IsNullOrWhiteSpace(focusKeyword)))
                {
                    await UpdateAioSeoDataAsync(rootUrl, newPostId, seoDesc, focusKeyword);
                }

                // --- 11. Başarı Mesajı ve Yerel Veritabanı Güncellemesi ---
                DialogResult open = MessageBox.Show("İçerik başarıyla gönderildi! Görüntülemek ister misiniz?", "Başarılı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (open == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = postUrl, UseShellExecute = true });
                }

                UpdateBlogPostStatusInDb(bID, "Yayınlandı");
                if (m != null) m.listele();

                btn_send.Enabled = false; // Yayınlandığı için gönder butonu kapalı kalsın
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Ağ hatası: {httpEx.Message}\nURL'yi ve internet bağlantınızı kontrol edin.", "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show($"API yanıtı okunamadı: {jsonEx.Message}\nWordPress'ten gelen veri formatı bozuk olabilir.", "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmedik bir hata oluştu: {ex.Message}", "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // --- 12. Temizlik ---
                if (imagePathForUpload != null && imagePathForUpload.Contains("tempupload_") && File.Exists(imagePathForUpload))
                {
                    File.Delete(imagePathForUpload); // Sadece geçici dosyaları sil
                }

                // Formun durumuna göre butonları ayarla
                if (durum != "Yayınlandı")
                {
                    btn_send.Enabled = true;
                }
                btn_save.Enabled = true;
            }
        }

        private async Task<int> UploadMediaAsync(string apiBaseUrl, string imagePath)
        {
            try
            {
                using (var fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    var streamContent = new StreamContent(fileStream);
                    streamContent.Headers.Add("Content-Type", "image/jpeg");
                    streamContent.Headers.Add("Content-Disposition", $"attachment; filename=\"{Path.GetFileName(imagePath)}\"");

                    var response = await client.PostAsync($"{apiBaseUrl}/media", streamContent);
                    string responseString = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Görsel yüklenemedi: {response.ReasonPhrase}\n{responseString}", "Medya Yükleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }

                    var mediaObj = JsonSerializer.Deserialize<JsonElement>(responseString);
                    return mediaObj.GetProperty("id").GetInt32();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Görsel yüklenirken dosya hatası: {ex.Message}", "Medya Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // Yardımcı Metot: AIOSEO Güncelleme
        private async Task UpdateAioSeoDataAsync(string rootUrl, int postId, string description, string keyphrase)
        {
            var aioseoEndpoint = $"{rootUrl}/wp-json/myplugin/v1/update-aioseo";
            var aioseoData = new
            {
                post_id = postId,
                description = description,
                keyphrase = keyphrase
            };

            string aioseoJson = JsonSerializer.Serialize(aioseoData);
            var aioseoContent = new StringContent(aioseoJson, Encoding.UTF8, "application/json");

            var aioseoResponse = await client.PostAsync(aioseoEndpoint, aioseoContent);

            if (!aioseoResponse.IsSuccessStatusCode)
            {
                string aioseoError = await aioseoResponse.Content.ReadAsStringAsync();
                MessageBox.Show($"Yazı oluşturuldu ancak SEO verileri güncellenemedi: {aioseoResponse.ReasonPhrase}\n{aioseoError}\n\nEndpoint: {aioseoEndpoint}", "SEO Güncelleme Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Yardımcı Metot: Veritabanı Durum Güncelleme
        private void UpdateBlogPostStatusInDb(int blogId, string newStatus)
        {
            // ID geçerli değilse işlem yapma
            if (blogId <= 0) return;

            try
            {
                using (var connection = bgl.baglanti())
                using (var command = new SqlCommand("UPDATE Blog SET Durum = @status WHERE ID = @id", connection))
                {
                    command.Parameters.AddWithValue("@status", newStatus);
                    command.Parameters.AddWithValue("@id", blogId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yerel veritabanı durumu güncellenirken hata: {ex.Message}", "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // GetOrCreateTagId metodunuza küçük bir ekleme (URL düzeltmesi)
        private async Task<int> GetOrCreateTagId(string rootApiUrl, string tagName) // Bu metot artık `rootApiUrl` almalı
        {
            var tagsEndpoint = $"{rootApiUrl}/wp/v2/tags";

            // Önce etiketi ara
            var tagCheck = await client.GetAsync($"{tagsEndpoint}?search={Uri.EscapeDataString(tagName)}");
            tagCheck.EnsureSuccessStatusCode();
            var tagContent = await tagCheck.Content.ReadAsStringAsync();
            var tagResults = JsonSerializer.Deserialize<List<TermItem>>(tagContent);

            if (tagResults != null && tagResults.Any(t => t.name.Equals(tagName, StringComparison.OrdinalIgnoreCase)))
                return tagResults.First(t => t.name.Equals(tagName, StringComparison.OrdinalIgnoreCase)).id;

            // Bulunamazsa yeni etiket oluştur
            var newTag = new { name = tagName };
            var tagJson = JsonSerializer.Serialize(newTag);
            var response = await client.PostAsync(tagsEndpoint, new StringContent(tagJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var created = JsonSerializer.Deserialize<TermItem>(result);
            return created.id;
        }


        private async Task LoadCategoriesForSelectedSite()
        {
            //ckategori.Properties.Items.Clear();
            //string selectedSiteName = csite.SelectedItem?.ToString();
            //var selectedSite = blogSites.Find(s => s.Name.Equals(selectedSiteName, StringComparison.OrdinalIgnoreCase));
            //if (selectedSite == null) return;

            //HttpClient client = new HttpClient();
            //var auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{selectedSite.Username}:{selectedSite.AppPassword}"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);

            //var siteBaseUrl = selectedSite.ApiUrl.Replace("/posts", "");
            //var catResponse = await client.GetAsync(siteBaseUrl + "/categories?per_page=100");
            //var catJson = await catResponse.Content.ReadAsStringAsync();
            //categories = JsonSerializer.Deserialize<List<TermItem>>(catJson);

            //foreach (var cat in categories)
            //{
            //    ckategori.Properties.Items.Add(cat.name);
            //}
            ckategori.Properties.Items.Clear();
            categories.Clear();
            string selectedSiteName = csite.SelectedItem?.ToString();
            var selectedSite = blogSites.Find(s => s.Name.Equals(selectedSiteName, StringComparison.OrdinalIgnoreCase));
            if (selectedSite == null) return;

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes($"{selectedSite.Username}:{selectedSite.AppPassword}")));

                var siteBaseUrl = selectedSite.ApiUrl.Replace("/posts", "");
                var catResponse = await client.GetAsync(siteBaseUrl + "/categories?per_page=100");
                catResponse.EnsureSuccessStatusCode();

                var catJson = await catResponse.Content.ReadAsStringAsync();
                categories = JsonSerializer.Deserialize<List<TermItem>>(catJson);

                foreach (var cat in categories)
                {
                    ckategori.Properties.Items.Add(cat.name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategoriler yüklenemedi: {ex.Message}");
            }
        }

        private void tbaslik_TextChanged(object sender, EventArgs e)
        {
            labelControl10.Text = $"{tbaslik.Text.Length}/60";
        }

        private void taciklama_TextChanged(object sender, EventArgs e)
        {
            labelControl3.Text = $"{taciklama.Text.Length}/160";
        }

        string gorselYolu;
        void detaybul(int bID)
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM Blog WHERE ID = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", bID);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                csite.Text = dr["Site"].ToString();
                tbaslik.Text = dr["Baslik"].ToString();
                taciklama.Text = dr["Aciklama"].ToString();
                todak.Text = dr["OdakKelime"].ToString();
                tanahtar.Text = dr["AnahtarKelime"].ToString();
                ckategori.Text = dr["Kategori"].ToString();
                tarih.EditValue = Convert.ToDateTime(dr["Tarih"]);
                mmetin.Text = dr["Metin"].ToString();

                gorselYolu = dr["Gorsel"]?.ToString();
                if (!string.IsNullOrEmpty(gorselYolu) && File.Exists(gorselYolu))
                {
                    byte[] imgBytes = File.ReadAllBytes(gorselYolu);
                    using (var ms = new MemoryStream(imgBytes))
                    {
                        pictureEdit1.Image = new Bitmap(Image.FromStream(ms));
                    }
                }
                else
                {
                    pictureEdit1.Image = null;
                }
            }

            bgl.baglanti().Close();
        }

        void kaydet()
        {
            if (kayitdurum == "1")
            {

            }
            else
            {
                string gorselYolu = null;

                if (pictureEdit1.Image != null && !string.IsNullOrWhiteSpace(tbaslik.Text))
                {
                    string gorselKlasoru = @"R:\Blog\Gorseller";

                    // Dosya adı: blog_baslik.jpg (boşluklar tire, özel karakterler temizlenebilir)
                    string baslik = tbaslik.Text;
                    string slugBaslik = string.Concat(baslik
                        .ToLower()
                        .Replace(" ", "-")
                        .Where(c => char.IsLetterOrDigit(c) || c == '-'));

                    string gorselAdi = $"blog_{slugBaslik}.jpg";
                    gorselYolu = Path.Combine(gorselKlasoru, gorselAdi);

                    if (!Directory.Exists(gorselKlasoru))
                        Directory.CreateDirectory(gorselKlasoru);

                    if (File.Exists(gorselYolu))
                        File.Delete(gorselYolu);

                    using (Bitmap tempImage = new Bitmap(pictureEdit1.Image))
                    {
                        tempImage.Save(gorselYolu, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }

                }

                if (tarih.EditValue == null)
                {
                    MessageBox.Show("Lütfen bir tarih seçin.");
                    return;
                }

                SqlCommand add = new SqlCommand(@"insert into Blog (Site, Baslik, Aciklama, OdakKelime, AnahtarKelime, Kategori, Tarih, Gorsel,Metin,Durum)
            values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10) SET @ID = SCOPE_IDENTITY()", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", csite.Text);
                add.Parameters.AddWithValue("@a2", tbaslik.Text);
                add.Parameters.AddWithValue("@a3", taciklama.Text);
                add.Parameters.AddWithValue("@a4", todak.Text);
                add.Parameters.AddWithValue("@a5", tanahtar.Text);
                add.Parameters.AddWithValue("@a6", ckategori.Text);
                add.Parameters.AddWithValue("@a7", tarih.EditValue);
                add.Parameters.AddWithValue("@a8", string.IsNullOrEmpty(gorselYolu) ? DBNull.Value : (object)gorselYolu);
                add.Parameters.AddWithValue("@a9", mmetin.Text);
                add.Parameters.AddWithValue("@a10", "Taslak");
                add.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                add.ExecuteNonQuery();
                bID = Convert.ToInt32(add.Parameters["@ID"].Value);
                bgl.baglanti().Close();

                kayitdurum = "1";
                MessageBox.Show("Kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        string kayitdurum;
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (btn_save.Text == "Güncelle")
            {
                guncelle(bID);
            }
            else
            {
                kaydet();                
            }

            if (Application.OpenForms["BlogListe"] == null)
            { }
            else
            {
                m.listele();
            }
        }

        private void Wordpress_FormClosed(object sender, FormClosedEventArgs e)
        {
            gelis = null;
            int? bID = null;
            durum = null;
            kayitdurum = null;
        }

        void guncelle(int bID)
        {
            string gorselYolu = null;

            if (pictureEdit1.Image != null && !string.IsNullOrWhiteSpace(tbaslik.Text))
            {
                string gorselKlasoru = @"R:\Blog\Gorseller";
                string baslik = tbaslik.Text;
                string slugBaslik = string.Concat(baslik.ToLower().Replace(" ", "-").Where(c => char.IsLetterOrDigit(c) || c == '-'));
                string gorselAdi = $"blog_{slugBaslik}.jpg";
                gorselYolu = Path.Combine(gorselKlasoru, gorselAdi);

                if (!Directory.Exists(gorselKlasoru))
                    Directory.CreateDirectory(gorselKlasoru);

                if (File.Exists(gorselYolu))
                    File.Delete(gorselYolu);

                using (Bitmap tempImage = new Bitmap(pictureEdit1.Image))
                {
                    tempImage.Save(gorselYolu, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            SqlCommand guncelle = new SqlCommand(@"
                UPDATE Blog SET 
                    Site = @a1,
                    Baslik = @a2,
                    Aciklama = @a3,
                    OdakKelime = @a4,
                    AnahtarKelime = @a5,
                    Kategori = @a6,
                    Tarih = @a7,
                    Gorsel = @a8,
                    Metin = @a9,
                    Durum = @a10
                WHERE ID = @id", bgl.baglanti());

            guncelle.Parameters.AddWithValue("@a1", csite.Text);
            guncelle.Parameters.AddWithValue("@a2", tbaslik.Text);
            guncelle.Parameters.AddWithValue("@a3", taciklama.Text);
            guncelle.Parameters.AddWithValue("@a4", todak.Text);
            guncelle.Parameters.AddWithValue("@a5", tanahtar.Text);
            guncelle.Parameters.AddWithValue("@a6", ckategori.Text);
            guncelle.Parameters.AddWithValue("@a7", tarih.EditValue);
            guncelle.Parameters.AddWithValue("@a8", string.IsNullOrEmpty(gorselYolu) ? DBNull.Value : (object)gorselYolu);
            guncelle.Parameters.AddWithValue("@a9", mmetin.Text);
            guncelle.Parameters.AddWithValue("@a10", "Taslak"); // Durum alanı sabit veya seçime bağlı olabilir
            guncelle.Parameters.AddWithValue("@id", bID);

            guncelle.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Kayıt güncellendi.", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

    }
}
