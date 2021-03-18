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

```bash
cd U6144_SSD1306/python
sudo python3 ssd1306_stats_0.96inch.py
```
