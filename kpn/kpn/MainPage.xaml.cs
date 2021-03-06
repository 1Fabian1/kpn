﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.Storage;


//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace kpn
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    /// 
    
    public sealed partial class MainPage : Page
    {
        private readonly string win = "win.mp3";
        private readonly string fail = "fail.mp3";
        private readonly string draw = "draw.mp3";
        Gra gra = new Gra();
        public MainPage()
        {
            this.InitializeComponent();
            btKamienCzerwony.IsEnabled = false;
            btPapierCzerwony.IsEnabled = false;
            btNozyceCzerwony.IsEnabled = false;

        }
        
        
        private void btKamienNiebieski_Checked(object sender, RoutedEventArgs e)
        {
            btPapierNiebieski.IsChecked = false;
            btNozyceNiebieski.IsChecked = false;
            akcjaPoWyborze();
            btKamienNiebieski.IsChecked = false;  //na sam koniec
        }

        private void btPapierNiebieski_Checked(object sender, RoutedEventArgs e)
        {
            btKamienNiebieski.IsChecked = false;
            btNozyceNiebieski.IsChecked = false;
            akcjaPoWyborze();
            btPapierNiebieski.IsChecked = false;
            
        }

        private void btNozyceNiebieski_Checked(object sender, RoutedEventArgs e)
        {
            btKamienNiebieski.IsChecked = false;
            btPapierNiebieski.IsChecked = false;
            akcjaPoWyborze();
            btNozyceNiebieski.IsChecked = false;

        }

        
        public int parsujTextBox(TextBox textBlock)
        {
            return int.Parse(textBlock.Text);
        }

        public void zwiekszTextBoxO1(TextBox tura)
        {
            int turyINT = parsujTextBox(tura);
            turyINT++;
            tura.Text = turyINT.ToString();
        }

        public async void muzyka(string type)
        {
            MediaElement odtwarzacz = new MediaElement();
            odtwarzacz.AudioCategory = AudioCategory.Media;
            StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Folder = await Folder.GetFolderAsync(@"Assets");
            StorageFile file = await Folder.GetFileAsync(type);
            odtwarzacz.SetSource(await file.OpenAsync(FileAccessMode.Read), file.ContentType);
            odtwarzacz.Volume = 100;
            odtwarzacz.Play();
        }

        private void akcjaPoWyborze()
        {
            gra.symulujWcisniecie(btKamienCzerwony, btPapierCzerwony, btNozyceCzerwony);
            bool remis = gra.remis(btKamienCzerwony, btPapierCzerwony, btNozyceCzerwony, btKamienNiebieski, btPapierNiebieski, btNozyceNiebieski);
            if (remis == false)
            {
                bool wygranaNiebieski = gra.zwyciestwoNiebieski(btKamienCzerwony, btPapierCzerwony, btNozyceCzerwony, btKamienNiebieski, btPapierNiebieski, btNozyceNiebieski);
                if (wygranaNiebieski == true)
                {
                    muzyka(win);
                    zwiekszTextBoxO1(wynikNiebieski);
                    zwiekszTextBoxO1(tbTura);
                }
                if (wygranaNiebieski == false)
                {
                    muzyka(fail);
                    zwiekszTextBoxO1(wynikCzerwony);
                    zwiekszTextBoxO1(tbTura);
                }
            }
            else
            {
                muzyka(draw);
                zwiekszTextBoxO1(tbTura);
            }
            gra.pilnujGry(tbTura, btKamienNiebieski, btPapierNiebieski, btNozyceNiebieski);

            
        }
        
        private void doTablicyWynikow_Click(object sender, RoutedEventArgs e)
        {
            Punkty pkt = new Punkty(tbImie.Text, wynikNiebieski.Text);
            this.Frame.Navigate(typeof(TablicaWynikow), pkt);
        }

        private void pomoc_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pomoc));
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            gra.restartuj(tbTura, wynikNiebieski, wynikCzerwony, btKamienNiebieski, btPapierNiebieski, btNozyceNiebieski);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
