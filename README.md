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

