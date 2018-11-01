using ClassLibrary;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AUTOSALE_Entity_.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Page _Main;
        private Page _MainUA;
        private Page _MainRUS;
        private Page _Autorization;
        private Page _AutorizationUA;
        private Page _AutorizationRUS;        
        private Page _Autorization1;
        private Page _Autorization1UA;
        private Page _Autorization1RUS;
        private Page _Autorization2;
        private Page _Autorization2UA;
        private Page _Autorization2RUS;
        private Page _Ads1;
        private Page _Ads1RUS;
        private Page _Ads1UA;
        private Page _Ads2;
        private Page _Ads2RUS;
        private Page _Ads2UA;

        private Page _carentPage;
        private User _user;

        public User u
        {
            set
            {
                _user = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("u"));
            }
            get { return _user; }
        }

        public Page CurrentPage
        {
            set
            {
                _carentPage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentPage"));
            }
            get { return _carentPage; }
        }

        private double _frameOpacity;

        public event PropertyChangedEventHandler PropertyChanged;

        public double FrameOpacity
        {
            set { _frameOpacity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FrameOpacity"));
            }
            get { return _frameOpacity; }
        }

        public MainViewModel(User U)
        {
            u = U;
            _Main = new Pages.Main_Page(this);          
            _Autorization1 = new Pages.AutorizationPage1(this);
            _MainUA = new Pages.Main_PageUA(this);
            _MainRUS = new Pages.MainPageRUS(this);
            _Autorization = new Pages.AutorizationPage(this);
            _AutorizationUA = new Pages.AutorizationPageUA(this);
            _AutorizationRUS = new Pages.AutorizationPageRUS(this);
            _Autorization1UA = new Pages.AutorizationPage1UA(this);
            _Autorization1RUS = new Pages.AutorizationPage1RUS(this);
            _Autorization2 = new Pages.AutorizationPage2(this);
            _Autorization2UA = new Pages.AutorizationPage2UA(this);
            _Autorization2RUS = new Pages.AutorizationPage2RUS(this);
            _Ads1 = new Pages.AdsPage1(this);
            _Ads1RUS = new Pages.AdsPage1RUS(this);
            _Ads1UA = new Pages.AdsPage1UA(this);
            _Ads2 = new Pages.AdsPage2(this);
            _Ads2RUS = new Pages.AdsPage2RUS(this);
            _Ads2UA = new Pages.AdsPage2UA(this);
        
            FrameOpacity = 1;
            CurrentPage = _Main;
        }

        public ICommand bAds2UA_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Ads2UA)); }
        }

        public ICommand bAds2RUS_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Ads2RUS)); }
        }

        public ICommand bAds2_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Ads2)); }
        }

        public ICommand bAds1RUS_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Ads1RUS)); }
        }

        public ICommand bAds1UA_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Ads1UA)); }
        }

        public ICommand bAds1_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Ads1)); }
        }

        public ICommand bMenuAutoriz2_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Autorization2)); }
        }

        public ICommand bMenuAutoriz2UA_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Autorization2UA)); }
        }

        public ICommand bMenuAutoriz2RUS_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Autorization2RUS)); }
        }

        public ICommand bMenuMain_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Main)); }
        }

        public ICommand bMenuMainUA_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_MainUA)); }
        }

        public ICommand bMenuMainRUS_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_MainRUS)); }
        }

        public ICommand bMenuAutoriz_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Autorization)); }
        }

        public ICommand bMenuAutorizUA_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_AutorizationUA)); }
        }

        public ICommand bMenuAutorizRUS_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_AutorizationRUS)); }
        }
        
        public ICommand bMenuAutoriz1_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Autorization1)); }
        }

        public ICommand bMenuAutoriz1UA_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Autorization1UA)); }
        }

        public ICommand bMenuAutoriz1RUS_Click
        {
            get { return new RelayCommand(() => SlowOpacity(_Autorization1RUS)); }
        }

        private async void SlowOpacity(Page p)
        {
            
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
                CurrentPage = p;
               
                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
            });
        }
    }
    //public class Base_Autosale : DbContext
    //{
    //    public Base_Autosale()
    //        : base("name=Base_Autosale")
    //    {
    //    }
    //    virtual public DbSet<User> Users { get; set; }
    //    virtual public DbSet<Image> Images { get; set; }
    //    virtual public DbSet<Heading> Headings { get; set; }
    //    virtual public DbSet<City> Cities { get; set; }
    //    virtual public DbSet<Ads> Ads { get; set; }
    //    virtual public DbSet<Year> Years { get; set; }
    //    virtual public DbSet<Transmission> Transmissions { get; set; }
    //    virtual public DbSet<Fuel> Fuels { get; set; }
    //    virtual public DbSet<Engine> Engines { get; set; }
    //    virtual public DbSet<Trucks_Brand> Trucks_Brand { get; set; }
    //    virtual public DbSet<Trucs_Model> Trucs_Model { get; set; }
    //    virtual public DbSet<Moto_Brand> Moto_Brand { get; set; }
    //    virtual public DbSet<Moto_Model> Moto_Model { get; set; }
    //    virtual public DbSet<Car_Brand> Car_Brand { get; set; }
    //    virtual public DbSet<Car_Model> Car_Model { get; set; }
    //    virtual public DbSet<Bus_Brand> Bus_Brand { get; set; }
    //    virtual public DbSet<Bus_Model> Bus_Model { get; set; }
    //}

}
