using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using VR2_Klientrakendus.Models;
using VR2_Klientrakendus.ViewModels;

namespace VR2_Klientrakendus
{
    /// <summary>
    /// Interaction logic for Konotraat.xaml
    /// </summary>
    public partial class Konotraat : Window
    {
        private MainWindowVM _vm;
        private OpenFileDialog op;
        private string filePath;
        private bool isPicUploaded;
        private bool isSearchButtonDisabled;

        public Konotraat()
        {
            isPicUploaded = false;
            isSearchButtonDisabled = false;
            InitializeComponent();
            this.Loaded += Konotraat_Loaded;
        }

        private void Konotraat_Loaded(object sender, RoutedEventArgs e)
        {
            this._vm = new MainWindowVM();
            this._vm.LoadApplications();
            this._vm.LoadLogs();
            this.DataContext = _vm;
        }

        private void LbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            op = new OpenFileDialog();
            op.Title = "Vali pilt";
            op.Filter = "Toetatud faiulilaiendid|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                filePath = op.FileName;
                ImgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                    //Sets image source from uploaded path in XAML. //Määrab ära pildiallika üleslaadimise koha.
                isPicUploaded = true; //Picture is browsed. //pilti lehitsetakse.
            }
        }

        private void ApplyApplication(object sender, RoutedEventArgs e)
        {
            //if some of the fields are not filled with data.
            if (TxtAddress.Text.Equals("") || TxtCountry.Text.Equals("")
                || TxtFirstName.Text.Equals("")
                || TxtIdNumber.Text.Equals("")
                || TxtLastName.Text.Equals("")
                || TxtNationality.Text.Equals("")
                || TxtAddress.Text.Equals("")
                || TxtCounty.Text.Equals("")
                || TxtZipCode.Text.Equals("")
                || TxtIssuerFirstName.Text.Equals("")
                || TxtIssuerLastName.Text.Equals("")
                || TxtIdReceiptAddress.Text.Equals(""))
            {
                //All fields are not filled with data.
                ErrorBox.Text = "Kõik väljad peab ära täitma.";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else if (!Regex.IsMatch(TxtIdNumber.Text, @"^\d+$"))
            {
                //The identification number conatins letters.
                ErrorBox.Text = "Isikukood koosneb ainult numbritest";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else if (Regex.IsMatch(TxtCounty.Text, @"^\d+$"))
            {
                //County contains numbers.
                ErrorBox.Text = "Maakond ei tohi sisaldada numbreid.";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else if (Regex.IsMatch(TxtCounty.Text, @"^\d+$"))
            {
                //Country contains numbers.
                ErrorBox.Text = "Riik ei tohi sisaldada numbreid.";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else if (!Regex.IsMatch(TxtZipCode.Text, @"^\d+$"))
            {
                //Zip code contains letters.
                ErrorBox.Text = "Postiindeks koosneb ainult numbritest.";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else if (Regex.IsMatch(TxtFirstName.Text, @"^\d+$"))
            {
                //First name contains numbers.
                ErrorBox.Text = "Eesnimi ei tohi sisaldada numbreid.";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else if (!isPicUploaded)
            {
                //Picture is not uploaded.
                ErrorBox.Text = "Palun laadige ID kaardi pilt ka ülesse.";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else if (!isPicUploaded)
            {
                //Picture is not uploaded.
                ErrorBox.Text = "Palun laadige ID kaardi pilt ka ülesse.";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else if (DateOfBirthCal.ToString() == "")
            {
                ErrorBox.Text = "Palun määrake sünnikuupäev kalendrist.";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else if (ChkBoxWoman.IsChecked == false
                     && ChkBoxMan.IsChecked == false)
            {
                ErrorBox.Text = "Palun valige sugu.";
                ErrorBox.Visibility = Visibility.Visible;
            }
            else
            {
                //Sucessful form validation.
                Log log = new Log()
                {
                    LogText =
                        TxtFirstName.Text + " " + TxtLastName.Text + " isikukoodiga " + TxtIdNumber.Text +
                        " on lisatud andmebaasi",
                    Added = DateTime.Now,

                };

                string gender = "";
                if (ChkBoxWoman.IsChecked == true)
                {
                    gender = "N";
                }
                if (ChkBoxMan.IsChecked == true)
                {
                    gender = "M";
                }
                //define the object that will be posted to the server.
                IDApplication idApplication = new IDApplication()
                {
                    Added = DateTime.Now,
                    Address = TxtAddress.Text,
                    Birthdate = DateOfBirthCal.SelectedDate.ToString(),
                    Country = TxtCountry.Text,
                    County = TxtCounty.Text,
                    FirstName = TxtFirstName.Text,
                    LastName = TxtLastName.Text,
                    Nationality = TxtNationality.Text,
                    ZipCode = TxtZipCode.Text,
                    Gender = gender,
                    ImagePath = op.SafeFileName,
                    IdNumber = TxtIdNumber.Text,
                    IdReceiptAddress = TxtIdReceiptAddress.Text,
                    IssuerFirstName = TxtIssuerFirstName.Text,
                    IssuerLastName = TxtIssuerLastName.Text

                };
                _vm.AddImage(filePath); //uploads the image to the server
                _vm.AddApplication(idApplication); //posts id application to the server
                _vm.AddLog(log);
                TxtAddress.Text = "";
                TxtCountry.Text = "";
                TxtCounty.Text = "";
                TxtFirstName.Text = "";
                TxtLastName.Text = "";
                TxtNationality.Text = "";
                TxtZipCode.Text = "";
                TxtIdNumber.Text = "";
                TxtIdReceiptAddress.Text = "";
                TxtIssuerFirstName.Text = "";
                TxtIssuerLastName.Text = "";
                TxtDocNr.Text = "";
                var uriSource = new Uri(@"/Media/no-user-image.gif", UriKind.Relative);
                ImgPhoto.Source = new BitmapImage(uriSource);
                TxtIdNumber.Text = "";
                ErrorBox.Visibility = Visibility.Hidden;



                MessageBox.Show("Taotlus on esitatud");
            }
        }

        private void LbApplications_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //If selected index exists eg is bigger than -1 then the listitem is chosen.
            //Kui on selekteeritud indeks eksisteerib ehk on -1st 0 kohal, siis on midagi valitud. 
            if (LbApplications.SelectedIndex > -1)
            {
                //Fill Preview with data.
                //Täida eelvaade andmetega.
                TxtApplicationInfo.Visibility = Visibility.Hidden;
                GridApplicationInfo.Visibility = Visibility.Visible;
                var pictureUrl = "http://localhost:21855/" + _vm.IdApplications[LbApplications.SelectedIndex].ImagePath;
                ImgPhotoPreview.Source = new BitmapImage(new Uri(pictureUrl, UriKind.Absolute));
                TbAddress.Text = _vm.IdApplications[LbApplications.SelectedIndex].Address;
                TbConty.Text = _vm.IdApplications[LbApplications.SelectedIndex].County;
                TbCountry.Text = _vm.IdApplications[LbApplications.SelectedIndex].Country;
                TbDateOfBirth.Text = _vm.IdApplications[LbApplications.SelectedIndex].Birthdate;
                TbFirstName.Text = _vm.IdApplications[LbApplications.SelectedIndex].FirstName;
                TbGender.Text = _vm.IdApplications[LbApplications.SelectedIndex].Gender;
                TbIdNumber.Text = _vm.IdApplications[LbApplications.SelectedIndex].IdNumber;
                TbIssuerFirstName.Text = _vm.IdApplications[LbApplications.SelectedIndex].IssuerFirstName;
                TbIssuerLastName.Text = _vm.IdApplications[LbApplications.SelectedIndex].IssuerLastName;
                TbLastName.Text = _vm.IdApplications[LbApplications.SelectedIndex].LastName;
                TbNationality.Text = _vm.IdApplications[LbApplications.SelectedIndex].Nationality;
                TbZipCode.Text = _vm.IdApplications[LbApplications.SelectedIndex].ZipCode;
                TbDocNr.Text = _vm.IdApplications[LbApplications.SelectedIndex].IdNumber;
                TbReceiptAddress.Text = _vm.IdApplications[LbApplications.SelectedIndex].IdReceiptAddress;
                TbAdded.Text = _vm.IdApplications[LbApplications.SelectedIndex].Added.ToString();
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = TxtSearch.Text.ToLower();
            _vm.LoadApplicationsByFirstName(searchQuery);
            if (_vm.IdApplications.Count == 0)
            {
                //Kui andmeid ei leitud.
                TxtApplicationInfo.Visibility = Visibility.Visible;
                TxtApplicationInfo.Text = "";
            }
            GridApplicationInfo.Visibility = Visibility.Hidden;
            TxtApplicationInfo.Visibility = Visibility.Visible;
        }

        private void ChkBoxMan_Checked(object sender, RoutedEventArgs e)
        {
            ChkBoxWoman.IsChecked = false;
        }

        private void ChkBoxWoman_Checked(object sender, RoutedEventArgs e)
        {
            ChkBoxMan.IsChecked = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isSearchButtonDisabled)
            {

                if (TxtSearch.Text.Length > -1)
                {
                    BtnSearch.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                }
            }

        }

        private void searchWithoutButton_Checked(object sender, RoutedEventArgs e)
        {
            if (isSearchButtonDisabled)
            {
                isSearchButtonDisabled = false;
                BtnSearch.IsEnabled = true;
            }
            else
            {
                TextBox_TextChanged(sender, null);
                isSearchButtonDisabled = true;
                BtnSearch.IsEnabled = false;
            }
        }

    }
}
