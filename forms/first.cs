using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dyfilm_client_v2._0.forms
{
	public partial class first : dyfilm_client_v2._0.forms.Frame
	{
		public first()
		{
			InitializeComponent();
		}

        private async void first_Load(object sender, EventArgs e)
        {
			// first start delay (5 second)
			for (int i = 5; i > 0; i--)
			{
				title2.Text = i + "초 뒤 실행됩니다.";
				await Task.Delay(1000);
			}

			// main image load
			title1.Text = "서버에서 데이터를 불러오는 중입니다.";
			title2.Text = "메인 화면 이미지를 불러오고 있습니다.";
			String main_image_url = "https://film.szk.kr/device/main_image/get_image";
			String save_path = "src/main_image.jpg";
			try
			{
				byte[] imageBytes = await APIClient.RequestAsync(main_image_url, method: "GET");
				File.WriteAllBytes(save_path, imageBytes);
			} catch (Exception ee)
			{
				title1.Text = "오류가 발생했습니다. 실행할 수 없습니다.";
				title2.Text = ee.ToString();
            }

			// frame image load
			title2.Text = "프레임 이미지 정보를 불러오고 있습니다.";
			String frame_image_ㅇ_url = "https://film.szk.kr/device/frame/frame_list";



        }
    }
}
