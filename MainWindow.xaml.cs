using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarCodeUP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            spBarCode.Children.Clear();
            Random rnd = new Random();

            DateTime startDate = DateTime.Now.AddYears(-21);
            DateTime endDate = DateTime.Now;

            int randomYear = rnd.Next(startDate.Year, endDate.Year);
            int randomMonth = rnd.Next(1, 12);
            int randomDay = rnd.Next(1, DateTime.DaysInMonth(randomYear, randomMonth));
            DateTime randomDate = new DateTime(randomYear, randomMonth, randomDay);

            string code = "";
            string date = randomDate.ToString("dd/MM/yy");
            date = Convert.ToString(date).Replace(".", "");
            code += date;
            for (int i = 0; i < 6; i++)
            {
                code += rnd.Next(0, 9) + "";
            }
            int checknumber = GetCheckNumber(code);

            StackPanel SPCheckNumber = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Height = 100
            };

            TextBlock tbCheckNumber = new TextBlock
            {
                Text = checknumber + " ",
                FontSize = 16,
                TextAlignment = TextAlignment.Center,
            };

            StackPanel SPCheckNumbSpace = new StackPanel
            {
                Height = 80
            };
            SPCheckNumber.Children.Add(SPCheckNumbSpace);
            SPCheckNumber.Children.Add(tbCheckNumber);
            spBarCode.Children.Add(SPCheckNumber);

            string binarycode = "101";
            for (int i = 0; i < binarycode.Length; i++)
            {
                if (binarycode[i] == '1')
                {
                    Rectangle r = new Rectangle()
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 100
                    };
                    spBarCode.Children.Add(r);
                }
                else
                {
                    Rectangle r = new Rectangle()
                    {
                        Stroke = Brushes.White,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 100
                    };
                    spBarCode.Children.Add(r);
                }
            }

            string binarycodelp = EAN_13.GetContrNumb(checknumber);
            string binarycodelpNum = "";
            for (int i = 0; i < 6; i++)
            {
                switch (binarycodelp[i])
                {
                    case 'L':
                        binarycodelpNum += EAN_13.GetLeftL(code[i]);
                        break;
                    case 'R':
                        binarycodelpNum += EAN_13.GetRightR(code[i]);
                        break;
                    case 'G':
                        binarycodelpNum += EAN_13.GetG(code[i]);
                        break;
                }

            }

            StackPanel spLeftCodeAndNumber = new StackPanel() 
            {
                Orientation = Orientation.Vertical,
                Height = 100
            };

            StackPanel spLeftCode = new StackPanel()  
            {
                Orientation = Orientation.Horizontal,
            };

            for (int i = 0; i < binarycodelpNum.Length; i++)
            {
                if (binarycodelpNum[i] == '1')
                {
                    Rectangle r = new Rectangle()
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 80
                    };
                    spLeftCode.Children.Add(r);
                }
                else
                {
                    Rectangle r = new Rectangle()  
                    {
                        Stroke = Brushes.White,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 80
                    };
                    spLeftCode.Children.Add(r);  
                }
            }

            string leftNumber = " "; 
            for (int i = 0; i < 6; i++)
            {
                leftNumber += code[i] + " ";
            }

            TextBlock tbLeftNumber = new TextBlock()
            {
                Text = leftNumber,
                FontSize = 16,
                TextAlignment = TextAlignment.Center
            };

            spLeftCodeAndNumber.Children.Add(spLeftCode); 
            spLeftCodeAndNumber.Children.Add(tbLeftNumber);
            spBarCode.Children.Add(spLeftCodeAndNumber);

            binarycode = "01010";
            for (int i = 0; i < binarycode.Length; i++)
            {
                if (binarycode[i] == '1')
                {
                    Rectangle r = new Rectangle()
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 100
                    };
                    spBarCode.Children.Add(r);
                }
                else
                {
                    Rectangle r = new Rectangle()
                    {
                        Stroke = Brushes.White,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 100
                    };
                    spBarCode.Children.Add(r);
                }
            }

            binarycode = "";
            for (int i = 5; i < 12; i++)
            {
                binarycode += EAN_13.GetRightR(code[i]);
            }


            StackPanel spRightCodeAndNumber = new StackPanel() 
            {
                Orientation = Orientation.Vertical,
                Height = 100
            };

            StackPanel spRightCode = new StackPanel()  
            {
                Orientation = Orientation.Horizontal,
            };

            for (int i = 0; i < binarycode.Length; i++)
            {
                if (binarycode[i] == '1')
                {
                    Rectangle r = new Rectangle() 
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 80
                    };
                    spRightCode.Children.Add(r);
                }
                else
                {
                    Rectangle r = new Rectangle()  
                    {
                        Stroke = Brushes.White,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 80
                    };
                    spRightCode.Children.Add(r);  
                }
            }

            string rightNumber = " "; 
            for (int i = 6; i < 12; i++)
            {
                rightNumber += code[i] + " ";

            }

            TextBlock tbRightNumber = new TextBlock()
            {
                Text = rightNumber,
                FontSize = 16,
                TextAlignment = TextAlignment.Center
            };

            spRightCodeAndNumber.Children.Add(spRightCode); 
            spRightCodeAndNumber.Children.Add(tbRightNumber);
            spBarCode.Children.Add(spRightCodeAndNumber);

            binarycode = "101";
            for (int i = 0; i < binarycode.Length; i++)
            {
                if (binarycode[i] == '1')
                {
                    Rectangle r = new Rectangle()
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 100
                    };
                    spBarCode.Children.Add(r);
                }
                else
                {
                    Rectangle r = new Rectangle()
                    {
                        Stroke = Brushes.White,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 100
                    };
                    spBarCode.Children.Add(r);
                }
            }


        }


        public int GetCheckNumber(string code)
        {
            int CheckNumber, fNumber = 0, sNumber = 0;
            string checkNumberStr;
            for(int i =0;i<12;i+=2)
            {
                fNumber += Convert.ToInt32(code[i]);
            }
            fNumber *= 3;
            for (int i = 1; i < 12; i += 2)
            {
                sNumber += Convert.ToInt32(code[i]);
            }
            CheckNumber = sNumber + fNumber;
            checkNumberStr = CheckNumber + "";
            checkNumberStr = checkNumberStr.Substring(checkNumberStr.Length - 1, 1);
            CheckNumber = 10-Convert.ToInt32(checkNumberStr);
            if(CheckNumber==10)
            { 
                return 0;
            }
            return CheckNumber;
        }
    }
}
