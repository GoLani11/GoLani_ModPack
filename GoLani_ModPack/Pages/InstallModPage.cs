﻿using Microsoft.WindowsAPICodePack.Dialogs;
using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace GoLani_ModPack.Pages
{
    public partial class InstallModPage : UserControl
    {
        private string installPath; // 설치 경로를 저장할 변수
        private List<Mod> mods = new List<Mod>(); // 모드 정보를 담을 리스트

        public InstallModPage()
        {
            InitializeComponent();
            InitializeMods(); // 모드 리스트 초기화
        }

        // 모드 리스트를 초기화하는 메서드
        private void InitializeMods()
        {
            //SPT 타르코프 한글화 프로젝트
            mods.Add(new Mod("SPT 타르코프 한글화 프로젝트", new List<string> {
                "https://github.com/GoLani11/SPT-Korean-Project/releases/download/v1.0.4/spt_korean_localization_G.M.zip",
                "https://drive.google.com/uc?export=download&id=1ZHAS0Ns3lTrMLrWKy00W3alzp-9gT8Ni" }, SPTKRBox));

            //타르코프 로고 한글화
            mods.Add(new Mod("타르코프 로고 한글화", new List<string> {
                "https://github.com/GoLani11/GoLani.KoreanLogoChange/releases/download/v1.0.1/GoLani-LogoChange.zip"}, SPTLogoKRBox));

            //SPT 타르코프 아이템 텍스처 한글화 프로젝트 - 기본
            mods.Add(new Mod("SPT 타르코프 아이템 텍스처 한글화 프로젝트 - 기본", new List<string> {
                "https://github.com/GoLani11/GoLani.ItemTextureKoreanChange/releases/download/v1.0.2/GoLani-ItemTextureKoreanChange.zip" }, SPTTexDefaultBtn));

            //SPT 타르코프 아이템 텍스처 한글화 프로젝트 - 4096
            mods.Add(new Mod("SPT 타르코프 아이템 텍스처 한글화 프로젝트 - 4096", new List<string> {
                "https://drive.google.com/uc?export=download&id=1bp2ewi3gx0kRkbkz1u1I0aCYBlPnceEC" }, SPTTex4096Btn));

            


            //SAIN
            mods.Add(new Mod("SAIN", new List<string> { "https://github.com/Solarint/SAIN/releases/download/v3.1.0-Release/SAIN-3.1.0-Release.7z",
                "https://github.com/DrakiaXYZ/SPT-BigBrain/releases/download/1.1.0/DrakiaXYZ-BigBrain-1.1.0.7z",
                "https://github.com/DrakiaXYZ/SPT-Waypoints/releases/download/1.5.2/DrakiaXYZ-Waypoints-1.5.2.7z" }, SAINBox));
            mods.Add(new Mod("SAIN - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1rdV7fuioPYAPVuhrdM8kZ-wONnpRmOor" }, SAINKRBox));

            //Donut
            mods.Add(new Mod("Donut", new List<string> { "https://github.com/p-kossa/nookys-swag-presets-spt/releases/download/v3.5.1/SWAG-Donuts-v3.5.1-SPT39x.zip",
            "https://github.com/Nympfonic/UnityToolkit/releases/download/v1.0.1/UnityToolkit-1.0.1.7z",
            "https://github.com/DrakiaXYZ/SPT-Waypoints/releases/download/1.5.2/DrakiaXYZ-Waypoints-1.5.2.7z" }, DonutBox));
            mods.Add(new Mod("Donut - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1_J1vetb4_lkBRP-qlHTw_I1_8BPDAZkl" }, DonutKRBox));

            //Realism
            mods.Add(new Mod("SPT Realism Mod", new List<string> {
                "https://github.com/space-commits/SPT-Realism-Mod-Client/releases/download/v1.4.8/Realism-Mod-v1.4.8-SPT-v3.9.8.zip" }, RealismBox));
            mods.Add(new Mod("SPT Realism Mod - KR", new List<string> {
                "" }, RealismKRBox));

            //Questing Bots
            mods.Add(new Mod("Questing Bots", new List<string> { "https://github.com/dwesterwick/SPTQuestingBots/releases/download/0.8.0/DanW-SPTQuestingBots.zip",
            "https://github.com/DrakiaXYZ/SPT-BigBrain/releases/download/1.1.0/DrakiaXYZ-BigBrain-1.1.0.7z",
            "https://github.com/DrakiaXYZ/SPT-Waypoints/releases/download/1.5.2/DrakiaXYZ-Waypoints-1.5.2.7z" }, QuestingBotsBox));
            mods.Add(new Mod("Questing Bots - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1VjkzFQuVKe2zfhFSAPjpVqfNvyzBcnw1" }, SAINKRBox));

            //Dynamic Maps
            mods.Add(new Mod("Dynamic Maps", new List<string> {
                "https://github.com/CJ-SPT/SPT-DynamicMaps/releases/download/V0.4.3/DynamicMaps-0.4.3-d5be034f.zip" }, MapsBox));
            mods.Add(new Mod("Dynamic Maps - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1H7K8swBDfmrYAtBF_gTsDteReN7Nazax" }, MapsKRBox));

            //Amands Graphics
            mods.Add(new Mod("Amands Graphics", new List<string> {
                "https://github.com/Amands2Mello/AmandsGraphics/releases/download/1.6.3/AmandsGraphics.1.6.3.zip" }, GraphicsBox));
            mods.Add(new Mod("Amands Graphics - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1ZeTWNfvnFoycyUE9yRNdznBY-Mgj7LGC" }, GraphicsKRBox));

            //Game Panel HUD
            mods.Add(new Mod("Game Panel HUD", new List<string> {
                "https://www.dropbox.com/scl/fi/0ghv6uqfile37uft1p8i5/kmyuhkyuk-GamePanelHUD-Release_3.1.1.7z?rlkey=23wkbn0tfx8ltligrbx4efyq9&st=rzvypvzl&dl=1",
            "https://dev.sp-tarkov.com/kmyuhkyuk/EFTApi/releases/download/1.2.2/kmyuhkyuk-EFTApi-%28Release_1.2.2%29.7z" }, HudBox));
            mods.Add(new Mod("Game Panel HUD - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1g6wJqsjctHsqDlYsRVNsbpbr3sSnHscD" }, HudKRBox));

            //De-Clutterer
            mods.Add(new Mod("De-Clutterer", new List<string> {
                "https://github.com/CJ-SPT/DeClutterer/releases/download/V1.2.4/Declutterer.7z", }, CluttererBox));
            mods.Add(new Mod("De-Clutterer - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1TcjGPg4KRaW3zdXP49fCDOhiErnejy8E" }, CluttererKRBox));

            //Boss Notifier
            mods.Add(new Mod("Boss Notifier", new List<string> {
                "https://github.com/m-barneto/BossNotifier/releases/download/v1.5.0/BossNotifier.zip", }, NotifierBox));
            mods.Add(new Mod("Boss Notifier - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1vvwt0ihzeUH6dZCT6m7xKjAsHLSYklDt" }, NotifierKRBox));

            //Fontaine's FOV Fix
            mods.Add(new Mod("Fontaine's FOV Fix", new List<string> {
                "https://github.com/space-commits/SPT-FOV-Fix/releases/download/v2.1.8/Fontaine-FOV-Fix-v2.1.8-SPT-v3.9.8.zip", }, FOVFixBox));
            mods.Add(new Mod("Fontaine's FOV Fix - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1lUPX3Rere4DxGDVUNvfmEjBoP1dkMroM" }, FOVFixKRBox));

            //Dad Gamer Mode
            mods.Add(new Mod("Dad Gamer Mode", new List<string> {
                "https://github.com/dvize/DadGamerMode/releases/download/v1.9.3/dvize.DadGamerMode-v1.9.3.0.zip", }, DadGamerBox));
            mods.Add(new Mod("Dad Gamer Mode - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1qpY8QtM9bRl0GZUEFHuT87Op4ihCQNai" }, DadGamerKRBox));

            //Personal Trainer
            mods.Add(new Mod("Personal Trainer", new List<string> {
                "https://drive.google.com/uc?export=download&id=19KooBlV5GSDlKSpOV2qR6ZmVyRTIT-0z", }, TrainerBox));
            mods.Add(new Mod("Personal Trainer - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1gTZQ0WgFN0b5gXqJPczXjJNE7nRhc31u" }, TrainerKRBox));

            //Grenade Indicator
            mods.Add(new Mod("Grenade Indicator", new List<string> {
                "https://github.com/Solarint/GrenadeIndicator/releases/download/v1.0/GrenadeIndicator-1.0-Release.7z", }, GrenadeBox));
            mods.Add(new Mod("Grenade Indicator - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1mBjrkeRceF4SXJDt9nvN_8acKgXzBTo4" }, GrenadeKRBox));

            //Audio Accessibility Indicators
            mods.Add(new Mod("Audio Accessibility Indicators", new List<string> {
                "https://github.com/acidphantasm/acidphantasm-accessibilityindicators/releases/download/1.2.0/acidphantasm-accessibilityindicators.zip", }, AudioBox));
            mods.Add(new Mod("Audio Accessibility Indicators - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1B1Cz3TYXU5IxkodYiaHNYqKNRpP9tu9G" }, AudioKRBox));

            //Item Context Menu 한글화 포함
            mods.Add(new Mod("Item Context Menu - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1XDu3906GfomsoRL2EfR-mlQcbzR9FbMz" }, ContextMenuBox));

            //SamSWAT's Fire Support
            mods.Add(new Mod("SamSWAT's Fire Support", new List<string> {
                "https://github.com/Nympfonic/SamSWAT.FireSupport.ArysReloaded/releases/download/v2.2.4/SamSWAT-FireSupport-ArysReloaded-2.2.4.7z", }, FireSupportBox));
            mods.Add(new Mod("SamSWAT's Fire Support - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1cEDPJOowm4EBuNBhv69zKRkrN2XDFVe7" }, FireSupportKRBox));

            //Trader Modding and Improved Weapon Building
            mods.Add(new Mod("Trader Modding and Improved Weapon Building", new List<string> {
                "https://github.com/Soulztorm/ChooChoo-TraderModding/releases/download/1.8.0/ChooChoo-Tradermodding-1.8.0.zip", }, ModdingBox));
            mods.Add(new Mod("Trader Modding and Improved Weapon Building - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1_o2h9qGeaZT00uF7tk2PNOJKb8QoBUQn" }, ModdingKRBox));

            //Borkel's Bloody Bullet Wounds + Particles + Splatters
            mods.Add(new Mod("Borkel's Bloody Bullet Wounds + Particles + Splatters", new List<string> {
                "https://github.com/Borkel/Blood-Particles/releases/download/1.2.3/BBBWP-1.2.3.zip", }, BloodyBox));
            mods.Add(new Mod("Borkel's Bloody Bullet Wounds + Particles + Splatters - KR", new List<string> {
                "https://drive.google.com/uc?export=download&id=1WuWkvepJiiifZb3kleA7FeOPSnPrZDQK" }, BloodyKRBox));

            //Visceral Dismemberment
            mods.Add(new Mod("Visceral Dismemberment - KR", new List<string> {
                "" }, VisceralBox));

            // 다른 모드들도 동일하게 추가
        }

        // 경로 선택 버튼 클릭 이벤트
        private void LinkBtn_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                installPath = dialog.FileName;
                LinkBox.Text = "SPT 모드 설치 경로 : " + installPath;
            }
        }

        // 모드 설치 버튼 클릭 이벤트
        private async void InstallBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(installPath))
            {
                MessageBox.Show("먼저 설치 경로를 선택해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InstallBtn.Enabled = false; // 다운로드 버튼 비활성화
            InstallLogBox.Text = ""; // 다운로드 로그 초기화
            InstallLogBox.Text += "설치가 시작되었습니다...\r\n";

            foreach (var mod in mods)
            {
                // Initialize isSelected to false
                bool isSelected = false;

                // Check if the mod uses a CheckBox and if it's checked
                if (mod.CheckBox != null)
                {
                    isSelected = mod.CheckBox.Checked;
                }
                // Check if the mod uses a RadioButton and if it's checked
                else if (mod.RadioButton != null)
                {
                    isSelected = mod.RadioButton.Checked;
                }

                // If the mod is selected, proceed with installation
                if (isSelected)
                {
                    InstallLogBox.Text += $"{mod.Name} 다운로드 및 설치 중...\r\n";

                    try
                    {
                        foreach (var url in mod.DownloadUrls)
                        {
                            InstallLogBox.Text += $"{url}에서 파일 다운로드 중...\r\n";

                            // HttpClient를 사용하여 파일 다운로드 및 파일 이름 추출
                            using (var client = new HttpClient())
                            {
                                client.Timeout = TimeSpan.FromMinutes(30); // 타임아웃 설정

                                using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                                {
                                    response.EnsureSuccessStatusCode();

                                    // 파일 이름 추출
                                    string fileName = GetFileNameFromResponse(response, mod.Name);

                                    string archiveFilePath = Path.Combine(installPath, fileName);

                                    // 파일 다운로드 및 저장
                                    using (var fs = new FileStream(archiveFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                                    {
                                        await response.Content.CopyToAsync(fs);
                                    }

                                    InstallLogBox.Text += $"{fileName} 다운로드 완료.\r\n";

                                    // 압축 해제
                                    InstallLogBox.Text += $"{fileName} 압축 해제 중...\r\n";

                                    // 압축 파일 열기
                                    using (var archive = ArchiveFactory.Open(archiveFilePath))
                                    {
                                        foreach (var entry in archive.Entries)
                                        {
                                            if (!entry.IsDirectory)
                                            {
                                                entry.WriteToDirectory(installPath, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                                            }
                                        }
                                    }

                                    InstallLogBox.Text += $"{fileName} 압축 해제 완료.\r\n";

                                    // 압축 파일 삭제
                                    System.IO.File.Delete(archiveFilePath);
                                    InstallLogBox.Text += $"{fileName} 압축 파일 삭제 완료.\r\n";
                                }
                            }
                        }

                        InstallLogBox.Text += $"{mod.Name} 설치 완료.\r\n";
                    }
                    catch (Exception ex)
                    {
                        InstallLogBox.Text += $"{mod.Name} 설치 중 오류 발생: {ex.Message}\r\n";
                    }
                }
            }

            // readme 또는 README 텍스트 파일 삭제
            DeleteReadmeFiles();

            InstallLogBox.Text += "설치가 완료되었습니다.\r\n";
            MessageBox.Show("선택한 모드들이 모두 설치되었습니다.", "다운로드 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

            InstallBtn.Enabled = true; // 다운로드 버튼 활성화
                                       // 필요한 변수 초기화 (필요하다면 추가)
        }


        // HTTP 응답에서 파일 이름을 추출하는 메서드
        private string GetFileNameFromResponse(HttpResponseMessage response, string defaultName)
        {
            string fileName = defaultName + ".zip"; // 기본 파일 이름

            if (response.Content.Headers.ContentDisposition != null)
            {
                fileName = response.Content.Headers.ContentDisposition.FileName.Trim('"');
            }
            else if (response.Content.Headers.Contains("Content-Disposition"))
            {
                var contentDisposition = response.Content.Headers.GetValues("Content-Disposition").FirstOrDefault();
                if (!string.IsNullOrEmpty(contentDisposition))
                {
                    const string fileNameKey = "filename=";
                    var fileNameIndex = contentDisposition.IndexOf(fileNameKey, StringComparison.OrdinalIgnoreCase);
                    if (fileNameIndex >= 0)
                    {
                        fileName = contentDisposition.Substring(fileNameIndex + fileNameKey.Length).Trim('"');
                    }
                }
            }

            return fileName;
        }

        // readme 또는 README 텍스트 파일 삭제하는 메서드
        private void DeleteReadmeFiles()
        {
            try
            {
                var readmeFiles = Directory.GetFiles(installPath, "*", SearchOption.AllDirectories)
                    .Where(file => Path.GetFileName(file).Equals("readme.txt", StringComparison.OrdinalIgnoreCase)
                                || Path.GetFileName(file).Equals("readme.md", StringComparison.OrdinalIgnoreCase)
                                || Path.GetFileName(file).Equals("README.txt", StringComparison.OrdinalIgnoreCase)
                                || Path.GetFileName(file).Equals("ReadMe.txt", StringComparison.OrdinalIgnoreCase)
                                || Path.GetFileName(file).Equals("README.md", StringComparison.OrdinalIgnoreCase));

                foreach (var file in readmeFiles)
                {
                    System.IO.File.Delete(file);
                    InstallLogBox.Text += $"{file} 파일 삭제 완료.\r\n";
                }
            }
            catch (Exception ex)
            {
                InstallLogBox.Text += $"readme 파일 삭제 중 오류 발생: {ex.Message}\r\n";
            }
        }

        private void InstallModPage_Load(object sender, EventArgs e)
        {
            // 필요 시 초기화 코드 추가
        }

        // 텍스처 한글화 버튼 클릭시 라디오버튼 활성화
        private void SPTTexKRBox_CheckedChanged(object sender, EventArgs e)
        {
            SPTTexDefaultBtn.Enabled = true;
        }
    }

    // 모드 정보를 담는 클래스
    public class Mod
    {
        public string Name { get; set; }
        public List<string> DownloadUrls { get; set; }
        public CheckBox CheckBox { get; set; }
        public RadioButton RadioButton { get; set; }

        // 체크박스용 생성자
        public Mod(string name, List<string> downloadUrls, CheckBox checkBox)
        {
            Name = name;
            DownloadUrls = downloadUrls;
            CheckBox = checkBox;
            RadioButton = null;
        }

        // 라디오버튼용 생성자
        public Mod(string name, List<string> downloadUrls, RadioButton radioButton)
        {
            Name = name;
            DownloadUrls = downloadUrls;
            CheckBox = null;
            RadioButton = radioButton;
        }
    }

}