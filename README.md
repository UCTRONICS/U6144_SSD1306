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

## Custom display temperature type 
- Open the U6143_ssd1306/C/ssd1306_i2c.h file. You can modify the value of the TEMPERATURE_TYPE variable to change the type of temperature displayed. (The default is Fahrenheit)
![EasyBehavior](https://github.com/UCTRONICS/pic/blob/master/OLED/select_temperature.jpg)


## Custom display IPADDRESS_TYPE type 
- Open the U6143_ssd1306/C/ssd1306_i2c.h file. You can modify the value of the IPADDRESS_TYPE variable to change the type of IP displayed. (The default is ETH0)
![EasyBehavior](https://github.com/UCTRONICS/pic/blob/master/OLED/select_ip.jpg)

## Custom display information 
- Open the U6143_ssd1306/C/ssd1306_i2c.h file. You can modify the value of the IP_SWITCH variable to determine whether to display the IP address or custom information. (The custom IP address is displayed by default)
![EasyBehavior](https://github.com/UCTRONICS/pic/blob/master/OLED/custom_display.jpg)
