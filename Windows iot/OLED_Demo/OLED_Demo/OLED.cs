
using System;
using System.Diagnostics;
using Windows.Devices.Enumeration;
using System.Threading.Tasks;
using Windows.Devices.I2c;

namespace OLED_Demo
{
    class SSD1306 : IDisposable
    {
        CharactersTable table = new CharactersTable();
        private const UInt32 SCREEN_WIDTH_PX = 128;                         /* Number of horizontal pixels on the display */
        private const UInt32 SCREEN_HEIGHT_PX = 64;                         /* Number of vertical pixels on the display   */
        private I2cDevice sensor;
        const string I2CControllerName = "I2C1";
        const byte OLED_ADDR = 0x3C;
        public async Task InitializeAsync()
        {
            var settings = new I2cConnectionSettings(OLED_ADDR);
            settings.BusSpeed = I2cBusSpeed.StandardMode;
            var controller = await I2cController.GetDefaultAsync();
            sensor = controller.GetDevice(settings);
            InitCommand();
            FillScreen(0x00, 0x00);
        }


        public void ShowString(int x, int y, string chr, byte Char_Size)
        {
            for (int i = 0; i < chr.Length; i++)
            {
                ShowChar(x, y, chr[i], Char_Size);
                x += 8;
                if (x > SCREEN_WIDTH_PX-8)
                {
                    x = 0;
                    y += 2;
                }
            }
        }
        public void ClearScreen()
        {
            for (int i = 0; i < 8; i++)
            {
                WriteCommand((byte)(0xb0 + i));
                WriteCommand(0x00);
                WriteCommand(0x10);
                for (int n = 0; n < SCREEN_WIDTH_PX; n++) WriteData(0);
            }
        }
        public void ShowChar(int x, int y, char chr, byte Char_Size)
        {
            int i = 0;
            int index = chr-' ';
            if (x > SCREEN_WIDTH_PX - 1) { x = 0; y = y + 2; }
            if (Char_Size == 16)
            {
                SetPoint(x, y);
                for (i = 0; i < 8; i++)
                {
                    WriteData(table.Table16x8[index * 16 + i]);
                }
                SetPoint(x, y + 1);
                for (i = 0; i < 8; i++)
                {
                    WriteData(table.Table16x8[index * 16 + i + 8]);
                }
            }
            else
            {
                SetPoint(x, y);
                for (i = 0; i < 6; i++)
                {
                    WriteData(table.Table6x8[index*6+i]);
                }
                    

            }
        }

        public void DrawBMP(int x0, int y0, int x1, int y1, byte[] buffer)
        {
            int j = 0;
            int x, y;
            for (y=y0; y < y1; y++)
            {
                SetPoint(x0, y);
                for (x = x0; x < x1; x++)
                {
                    WriteData(buffer[j++]);
                }
            }
        }

        public int oled_pow(int m, int n)
        {
            int result = 1;
            for (int i = 0; i < n; i++)
            {
                result *= m;
            }
            return result;
        }

        public void ShowNum(int x, int y, int num, byte len, byte Char_Size)
        {
            int t, temp;
            int enshow = 0;
            for (t = 0; t < len; t++)
            {
                temp = (num / oled_pow(10, len - t - 1)) % 10;
                if (enshow == 0 && t < (len - 1))
                {
                    if (temp == 0)
                    {
                        ShowChar(x + (Char_Size / 2) * t, y, ' ', Char_Size);
                        continue;
                    }
                    else enshow = 1;

                }
                ShowChar(x + (Char_Size / 2) * t, y, (char)(temp+48), Char_Size);
            }
        }

        public void WriteCommand(byte command)
        {
            sensor.Write(new byte[] { 0x00, command });
        }

        public void WriteData(byte data)
        {
            sensor.Write(new byte[] { 0x40, data });
        }


        public void SetPoint(int x, int y)
        {
            WriteCommand((byte)(0xb0 + y));
            WriteCommand((byte)(((x & 0xf0) >> 4) | 0x10));
            WriteCommand((byte)((x & 0x0f) | 0x01));
        }

        public void FillScreen(byte data1, byte data2)
        {
            byte x, y;    
            WriteCommand(0x02);    /*set lower column address*/
            WriteCommand(0x10);    /*set higher column address*/
            WriteCommand(0xB0);    /*set page address*/
            for (y = 0; y < 8; y++)
            {
                WriteCommand((byte)(0xB0 + y));    /*set page address*/
                WriteCommand(0x02);    /*set lower column address*/
                WriteCommand(0x10);    /*set higher column address*/
                for (x = 0; x < 64; x++)
                {
                    WriteData(data1);
                    WriteData(data2);
                }
            }
        }


        public I2cDevice GetDevice()
        {
            return sensor;
        }

        public void Dispose()
        {
            sensor.Dispose();
        }

        private void InitCommand()
        {
            WriteCommand(0xAE);//display off 
            WriteCommand(0x00);//set lower column address
            WriteCommand(0x10);//set higher column address
            WriteCommand(0x40);//set display start line
            WriteCommand(0xB0);//set page address
            WriteCommand(0x81);//contrast ratio
            WriteCommand(0xCF);//0~255
            WriteCommand(0xA1);//set segment remap
            WriteCommand(0xA6);//normal / reverse
            WriteCommand(0xA8);//multiplex ratio
            WriteCommand(0x3F);//duty = 1/64
            WriteCommand(0xC8);//Com scan direction
            WriteCommand(0xD3);//set display offset
            WriteCommand(0x00);
            WriteCommand(0xD5);//set osc division
            WriteCommand(0x80);
            WriteCommand(0xD9);//set pre-charge period
            WriteCommand(0xF1);
            WriteCommand(0xDA);//set COM pins
            WriteCommand(0x12);
            WriteCommand(0xDB);//set vcomh
            WriteCommand(0x40);
            WriteCommand(0x8D);//set charge pump enable
            WriteCommand(0x14);
            WriteCommand(0xAF);//display ON
        }
    }
}
