using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace lab06
{
    public partial class WhiteboardClient : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Graphics g;
        private bool drawing = false;
        private Point previousPoint;
        private Pen currentPen;

        public WhiteboardClient()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            client = new TcpClient("127.0.0.1", 57531);
            stream = client.GetStream();

            Thread receiveThread = new Thread(ReceiveData);
            receiveThread.Start();
            currentPen = new Pen(Color.Black, 2);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            previousPoint = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                g.DrawLine(currentPen, previousPoint, e.Location);
                SendDrawData(previousPoint, e.Location);
                previousPoint = e.Location;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void SendDrawData(Point start, Point end)
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write(start.X);
            bw.Write(start.Y);
            bw.Write(end.X);
            bw.Write(end.Y);
            bw.Write(currentPen.Color.ToArgb());
            bw.Write(currentPen.Width);
            byte[] data = ms.ToArray();
            stream.Write(data, 0, data.Length);
        }

        private void ReceiveData()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                MemoryStream ms = new MemoryStream(buffer, 0, bytesRead);
                BinaryReader br = new BinaryReader(ms);
                int startX = br.ReadInt32();
                int startY = br.ReadInt32();
                int endX = br.ReadInt32();
                int endY = br.ReadInt32();
                Color penColor = Color.FromArgb(br.ReadInt32());
                float penWidth = br.ReadSingle();
                Invoke((MethodInvoker)delegate
                {
                    Pen pen = new Pen(penColor, penWidth);
                    g.DrawLine(pen, new Point(startX, startY), new Point(endX, endY));
                });
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bitmap, new Rectangle(0, 0, panel1.Width, panel1.Height));
            bitmap.Save("whiteboard.png", System.Drawing.Imaging.ImageFormat.Png);
            client.Close();
            this.Close();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentPen.Color = colorDialog.Color;
            }
        }

        private void btnThickness_Click(object sender, EventArgs e)
        {
            float thickness;
            if (float.TryParse(thicknessTextBox.Text, out thickness))
            {
                currentPen.Width = thickness;
            }
        }

        private void btnInsertImage_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
                string imageUrl = txtImageUrl.Text;
                try
                {
                    Image image = Image.FromFile(file);
                    g.DrawImage(image, new Point(0, 0));
                    SendImageData(image);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load image: " + ex.Message);
                }
            }
        }

        private void SendImageData(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] data = ms.ToArray();
            ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write(data.Length);
            bw.Write(data);
            byte[] buffer = ms.ToArray();
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
