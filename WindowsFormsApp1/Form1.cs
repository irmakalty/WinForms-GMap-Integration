using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Form açıldığında 
        private void Form1_Load(object sender, EventArgs e)
        {
            // Harita sağlayıcısını Google Maps olarak seçiyoruz
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            // Başlangıç noktası koordinatları (Örnek: İstanbul)
            gMapControl1.Position = new PointLatLng(41.0082, 28.9784);

            // Yakınlaştırma (Zoom) ayarları
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 18;
            gMapControl1.Zoom = 10;

            // Haritayı fare ile kaydırmak için sol tuşu atıyoruz
            gMapControl1.DragButton = MouseButtons.Left;
        }

        // 2. "Haritada Göster" butonuna tıklandığında çalışacak kodlar
        private void btnGoster_Click(object sender, EventArgs e)
        {
            try
            {
               
                double enlem = Convert.ToDouble(txtEnlem.Text.Replace(".", ","));
                double boylam = Convert.ToDouble(txtBoylam.Text.Replace(".", ","));

              
                gMapControl1.Position = new PointLatLng(enlem, boylam);
                gMapControl1.Zoom = 14;

                // Varsa eski işaretçileri temizle
                gMapControl1.Overlays.Clear();

                
                GMapOverlay isaretciKatmani = new GMapOverlay("Isaretciler");

                // Kırmızı renkli Google işaretçisini (Marker) oluşturma
                GMarkerGoogle isaretci = new GMarkerGoogle(new PointLatLng(enlem, boylam), GMarkerGoogleType.red_dot);

                // İşaretçiyi haritaya ekle
                isaretciKatmani.Markers.Add(isaretci);
                gMapControl1.Overlays.Add(isaretciKatmani);
            }
            catch (Exception)
            {
                // Hatalı veya boş veri girilirse programın çökmesin diye
                MessageBox.Show("Lütfen geçerli bir koordinat giriniz!\nÖrnek: 41,0082", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
