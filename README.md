# U6144_SSD1306
## C code
-  Enable i2c 
```bash
sudo raspi-config
```
Choose Interface Options 
Enable i2c
- Download library 
```bash
git clone https://github.com/UCTRONICS/U6144_SSD1306.git
```
- Compile the source code 
```bash
cd U6144_SSD1306/C 
```
```bash
make 
```
- Run the display

```bash 
cd U6144_SSD1306/C 
```
```bash 
./display 
```

## python code

## Install library files
```bash
sudo pip3 install rpi_ws281x adafruit-circuitpython-neopixel
sudo pip3 install adafruit-circuitpython-ssd1306
```
## Run
```bash
cd U6144_SSD1306/python
sudo python3 ssd1306_stats_0.96inch.py
```
## Add automatic start script
- Open the rc.local file 
```bash
sudo nano /etc/rc.local
```
- Add command to the rc.local file
```bash
cd /home/pi/U6144_SSD1306/C 
sudo make clean 
sudo make 
sudo ./display &
```
- reboot your system

# rpi3+windows 10 iot+SSD1306
This example shows the use of Raspberry Pi 3+windows 10 iot to drive SSD1306, 
the development software is Visual studio 2017, and the programming language is C#.


# Download driver
```bash
https://github.com/UCTRONICS/U6144_SSD1306
```

# windows 10 iot system installation download
Windows 10 iot mirror download and installation refer to the official:
```bash
https://youtu.be/JPRUbGIyODY
```

# visual studio 2017 installation download
```bash
https://visualstudio.microsoft.com/
```

# Visual studio 2017 environment configuration and use
Visual Studio 2017 environment configuration and driver operation refer to the following link
```bash
https://visualstudio.microsoft.com/
```

# Running effect chart
![EasyBehavior](https://github.com/UCTRONICS/pic/blob/master/windows%2010%20iot%2Bssd1306.jpg)