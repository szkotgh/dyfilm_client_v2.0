using dyfilm_client_v2._0.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dyfilm_client_v2._0.src.DataStruct;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dyfilm_client_v2._0.forms
{
	public partial class first : dyfilm_client_v2._0.forms.Frame
	{
		public first()
		{
			InitializeComponent();
		}

		private async void fail_cant_start(string msg)
		{
			progressBar1.Style = ProgressBarStyle.Marquee;

			title1.ForeColor = Color.Red;
			title1.Text = "덕영필름 클라이언트를 시작할 수 없습니다.";
			title2.Text = msg;

            for (int i = 10; i > 0; i--)
            {
                title2.Text = msg + "\n\n";
                title2.Text += i + "초 뒤 재시작됩니다.";
                await Task.Delay(1000);
            }

			Utils.RestartApplication();
			//Environment.Exit(1);
			return;
        }

		private void set_progressbar(int value)
		{
			progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = value;
		}

        private async void first_Load(object sender, EventArgs e)
        {
			try
			{
				Config.properties_init();
            }
			catch (Exception ee)
			{
				fail_cant_start("Properties에 필수 데이터가 누락되었습니다. 확인하십시오.");
				return;
			}
			Config.dir_init();

			//// first start delay (10 second)
			////set_progressbar(10);
			//progressBar1.Style = ProgressBarStyle.Marquee;
			//title1.Text = "덕영필름 클라이언트(v" + Config.version + ")를 시작합니다.";
			//for (int i = 10; i > 0; i--)
			//{
			//	title2.Text = "클라이언트 기본 정보\n";
			//	title2.Text += "version=" + Config.version + '\n';
			//	title2.Text += "auth_token=" + Config.auth_token + '\n';
			//	title2.Text += "process_url=" + Config.process_url + "\n\n";
			//	title2.Text += i + "초 뒤 실행됩니다.";
			//	await Task.Delay(1000);
			//}

			//// check device enable
			//set_progressbar(10);
			//title1.Text = "장치 인증 중입니다.";
			//title2.Text = "올바른 장치인지 확인합니다.";
			//string verify_token_url = Config.process_url + "/device/verify_token";
			//try
			//{
			//	byte[] auth_result_bytes = await APIClient.RequestAsync(verify_token_url, method: "GET");
			//	if (auth_result_bytes == null)
			//	{
			//		fail_cant_start("인증 토큰 오류입니다. 토큰을 확인하십시오.");
			//		return;
			//	}
			//	File.WriteAllBytes(Config.AUTH_RESULT_PATH, auth_result_bytes);

			//	string auth_result = File.ReadAllText(Config.AUTH_RESULT_PATH);
			//	DataStruct.VerifyToken auth_result_json = JsonSerializer.Deserialize<VerifyToken>(auth_result);

			//	if (auth_result_json.info[1].ToString() == "0")
			//	{
			//		fail_cant_start("비활성화된 장치입니다.\n" + "장치 아이디: " + auth_result_json.info[0].ToString());
			//		return;
			//	}

			//	progressBar1.Style = ProgressBarStyle.Marquee;
			//	title2.Text = "장치 인증에 성공했습니다.\ndesc=" + auth_result_json.info[2].ToString();
			//	await Task.Delay(1000);
			//}
			//catch (Exception ee)
			//{
			//	fail_cant_start("장치 인증에 실패했습니다.\n" + ee.ToString());
			//	return;
			//}

			//// main image load
			//set_progressbar(20);
			//title1.Text = "서버에서 데이터를 불러오는 중입니다.";
			//title2.Text = "메인 화면 이미지를 불러오고 있습니다.";
			//string main_image_url = Config.process_url + "/device/main_image/get_image";
			//try
			//{
			//	byte[] file_bytes = await APIClient.RequestAsync(main_image_url, method: "GET");
			//	File.WriteAllBytes(Config.MAIN_IMAGE_PATH, file_bytes);
			//}
			//catch (Exception ee)
			//{
			//	fail_cant_start("메인 화면 이미지 로드에 실패했습니다.\n" + ee.ToString());
			//	return;
			//}

			//// frame image load
			//// // frame info
			//set_progressbar(30);
			//title2.Text = "프레임 이미지 정보를 불러오고 있습니다.";
			//string frame_info_url = Config.process_url + "/device/frame/frame_list";
			//try
			//{
			//	byte[] file_bytes = await APIClient.RequestAsync(frame_info_url, method: "GET");
			//	File.WriteAllBytes(Config.FRAME_INFO_PATH, file_bytes);
			//}
			//catch (Exception ee)
			//{
			//	fail_cant_start("프레임 이미지 정보 로드에 실패했습니다.\n" + ee.ToString());
			//	return;
			//}

			//// // frame image
			//title2.Text = "프레임 이미지를 불러오고 있습니다.";
			//string frame_info_txt = File.ReadAllText(Config.FRAME_INFO_PATH);
			//DataStruct.FrameInfo frame_info_json = JsonSerializer.Deserialize<FrameInfo>(frame_info_txt);

			//int index = 0;
			//int frame_info_count = frame_info_json?.info?.Count ?? 0;
			//int pm_value = frame_info_count > 0 ? Convert.ToInt32(70 / frame_info_count) : 0;
			//foreach (var item in frame_info_json.info)
			//{
			//	index++;
			//	title2.Text = "프레임 이미지를 불러오고 있습니다. (" + frame_info_count + "/" + index + ")";
			//	set_progressbar(30 + (pm_value * index));

			//	if (item[1].ToString() == "0")
			//	{
			//		title2.Text += " 비활성화된 프레임. 수신을 건너뜁니다 . . .";
			//		await Task.Delay(1000);
			//		continue;
			//	}

			//	string frame_image_url = Config.process_url + "/device/frame/frame_get?f_id=" + item[0];
			//	string save_path = Path.Combine(Config.FRAME_PATH, item[2].ToString());
			//	try
			//	{
			//		byte[] frame_image_bytes = await APIClient.RequestAsync(frame_image_url, method: "GET");
			//		File.WriteAllBytes(save_path, frame_image_bytes);
			//	}
			//	catch (Exception ee)
			//	{
			//		fail_cant_start("프레임 이미지(f_id=" + item[0] + ") 로드에 실패했습니다.\n" + ee.ToString());
			//	}

			//}
			//set_progressbar(100);
			//await Task.Delay(300);

			//// complete load data
			//progressBar1.Style = ProgressBarStyle.Marquee;
			//title1.Text = "서버에서 데이터를 성공적으로 수신했습니다.";
			//title2.Text = "프로그램을 최적화 중입니다.";
			//set_progressbar(0);
			//int progress_value = 0;
			//while (progress_value < 100)
			//{
			//	Random rand = new Random();
			//	progress_value += rand.Next(1, 5);
			//	if (progress_value > 100)
			//		progress_value = 100;

			//	set_progressbar(progress_value);
			//	await Task.Delay(rand.Next(1, 100));
			//}
			//title2.Text = "최적화가 완료되었습니다.";
			//await Task.Delay(1000);
			//progressBar1.Style = ProgressBarStyle.Marquee;
			//await Task.Delay(2000);

			//title1.Text = "덕영필름 클라이언트(v" + Config.version + ")를 시작합니다.";
			//for (int i = 3; i > 0; i--)
			//{
			//	title2.Text = i + "초 뒤 실행됩니다.";
			//	await Task.Delay(1000);
			//}

			main newMain = new main();
            newMain.Owner = this;
            newMain.Show();
            this.Hide();
        }
    }
}
