import ctypes
import time

OLED = ctypes.CDLL('./OLED.so')

OLED.ssd1306_begin(0x00,0X3C)

while True:
	OLED.LCD_DisplayTemperature()
	time.sleep(3)
	OLED.LCD_DisPlayCpuSdMemory()
	time.sleep(3)
