/* =============================================================================================================================== *
 * | SUPPLY | ARDUINO | RELAY_1 | RELAY_2 | RELAY_3 | RELAY_4 | LINE_1 | LINE_2 | LINE_3 | LINE_4 | LCD | SERVO | PIEZO | CAMERA | *
 * ------------------------------------------------------------------------------------------------------------------------------- *
 * | 4.5V   |         | NO      | NO      | NO      | NO      |        |        |        |        |     |       |       |        | * 
 * | GND    |         |         |         |         |         | -      | -      | -      | -      |     |       |       |        | *
 * |        |         | COM     |         |         |         | +      |        |        |        |     |       |       |        | *
 * |        |         |         | COM     |         |         |        | +      |        |        |     |       |       |        | *
 * |        |         |         |         | COM     |         |        |        | +      |        |     |       |       |        | *
 * |        |         |         |         |         | COM     |        |        |        | +      |     |       |       |        | *
 * |        | 5V      | +       | +       | +       | +       |        |        |        |        | VCC | +     |       | +      | *
 * |        | 3.3V    |         |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | GND     | -       | -       | -       | -       |        |        |        |        | GND | -     | -     | -      | *
 * |        | A0      |         |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | A1      |         |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | A2      |         |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | A3      |         |         |         |         |        |        |        |        | SDA |       |       |        | *
 * |        | A4      |         |         |         |         |        |        |        |        | SCL |       |       |        | *
 * |        | A5      |         |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | D0      |         |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | D1      |         |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | D2      |         |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | D3      |         |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | D4      |         |         |         | SIGNAL  |        |        |        |        |     |       |       |        | *
 * |        | D5      |         |         | SIGNAL  |         |        |        |        |        |     |       |       |        | *
 * |        | D6      |         | SIGNAL  |         |         |        |        |        |        |     |       |       |        | *
 * |        | D7      | SIGNAL  |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | D8      |         |         |         |         |        |        |        |        |     |       | IN    |        | *
 * |        | D9      |         |         |         |         |        |        |        |        |     | IN    |       |        | *
 * |        | D10-D4  |         |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | D11-D5  |         |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | D12-D6  |         |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | D13-D7  |         |         |         |         |        |        |        |        |     |       |       |        | *
 * |        | SDA     |         |         |         |         |        |        |        |        |     |       |       | SDA    | *
 * |        | SCL     |         |         |         |         |        |        |        |        |     |       |       | SCL    | *
 * =============================================================================================================================== */
#include <HUSKYLENS.h>
#include <LiquidCrystal_I2C.h>
#include <Servo.h>
#include <SoftwareSerial.h>
#define SERVO 9
#define PIEZO 8
#define LINE_1 7
#define LINE_2 6
#define LINE_3 5
#define LINE_4 4
#define LINE_1_STATUS 13
#define LINE_2_STATUS 12
#define LINE_3_STATUS 11
#define LINE_4_STATUS 10
HUSKYLENS huskylens;
void printResult(HUSKYLENSResult result);
Servo servo;
LiquidCrystal_I2C lcd(0x27, 16, 2);
int angle = 0;
int point = 0;
void setup() {
  Serial.begin(9600);            // BPS
  Wire.begin();                  // CAMERA
  lcd.init();                    // LCD
  servo.attach(SERVO);           // MOTOR
  pinMode(PIEZO, OUTPUT);        // ALERT
  pinMode(LINE_1, OUTPUT);       // LINE1
  pinMode(LINE_2, OUTPUT);       // LINE2
  pinMode(LINE_3, OUTPUT);       // LINE3
  pinMode(LINE_4, OUTPUT);       // LINE4
  pinMode(LINE_1_STATUS, INPUT); // LINE1 STATUS
  pinMode(LINE_2_STATUS, INPUT); // LINE2 STATUS
  pinMode(LINE_3_STATUS, INPUT); // LINE3 STATUS
  pinMode(LINE_4_STATUS, INPUT); // LINE4 STATUS
  while (!huskylens.begin(Wire)) {
    Serial.println(F("Begin failed!"));
    Serial.println(F("1.Please recheck the \"Protocol Type\" in HUSKYLENS (General Settings>>Protocol Type>>I2C)"));
    Serial.println(F("2.Please recheck the connection."));
    delay(2000);
  }
}
void loop() {
  // DISPLAY PROGRESS
  lcd.backlight();
  lcd.display();
  lcd.setCursor(0, 0);
  lcd.print("LINE RUNNING... ");
  lcd.setCursor(0, 1);
  lcd.print("NO ISSUE...     ");
  // POP -- SERIAL --> ARDUINO : LINE 1 ~ 4 ON/OFF
  if (Serial.available()) {
    char signal = Serial.read();
    if (signal == '1') {
      digitalWrite(LINE_1, HIGH);
    }
    if (signal == '2') {
      digitalWrite(LINE_1, LOW);
    }
    if (signal == '3') {
      digitalWrite(LINE_2, HIGH);
    }
    if (signal == '4') {
      digitalWrite(LINE_2, LOW);
    }
    if (signal == '5') {
      digitalWrite(LINE_3, HIGH);
    }
    if (signal == '6') {
      digitalWrite(LINE_3, LOW);
    }
    if (signal == '7') {
      digitalWrite(LINE_4, HIGH);
    }
    if (signal == '8') {
      digitalWrite(LINE_4, LOW);
    }
  }
  // 100us INPUT CHECK
  int fault = 6; // ID VALUE
  if (!huskylens.request()) Serial.println(F("Fail to request data from HUSKYLENS, recheck the connection!"));
  else if(!huskylens.isLearned()) Serial.println(F("Nothing learned, press learn button on HUSKYLENS to learn one!"));
  else if(!huskylens.available()) Serial.println(F("No block or arrow appears on the screen!"));
  else {
    if (huskylens.available()) {
      HUSKYLENSResult result = huskylens.read();
      printResult(result);
      fault = result.ID - 1;
      // 0: NORMAL
      // 1: FAULT1
      // 2: FAULT2
      // 3: FAULT3
      // 4: FAULT4
      // 5: FAULT5
    }
  }
  if (digitalRead(LINE_1_STATUS)) {
    Serial.println("[LINE1 ON]:Y");
    if ((fault >= 0) && (fault <= 5)) {
      if (fault == 0) {
        Serial.println("[LINE1 FAULT]:0");
      }
      if (fault == 1) {
        Serial.println("[LINE1 FAULT]:1");
        tone(PIEZO, 800, 500);
        lcd.clear();
        lcd.setCursor(0, 0);
        lcd.print("    CAUTION!    ");
        lcd.setCursor(0, 1);
        lcd.print(" LINE_1 FAULT:1 ");
      }
      if (fault == 2) {
        Serial.println("[LINE1 FAULT]:2");
        tone(PIEZO, 800, 500);
        lcd.clear();
        lcd.setCursor(0, 0);
        lcd.print("    CAUTION!    ");
        lcd.setCursor(0, 1);
        lcd.print(" LINE_1 FAULT:2 ");
      }
      if (fault == 3) {
        Serial.println("[LINE1 FAULT]:3");
        tone(PIEZO, 800, 500);
        lcd.clear();
        lcd.setCursor(0, 0);
        lcd.print("    CAUTION!    ");
        lcd.setCursor(0, 1);
        lcd.print(" LINE_1 FAULT:3 ");
      }
      if (fault == 4) {
        Serial.println("[LINE1 FAULT]:4");
        tone(PIEZO, 800, 500);
        lcd.clear();
        lcd.setCursor(0, 0);
        lcd.print("    CAUTION!    ");
        lcd.setCursor(0, 1);
        lcd.print(" LINE_1 FAULT:4 ");
      }
      if (fault == 5) {
        Serial.println("[LINE1 FAULT]:5");
        tone(PIEZO, 800, 500);
        lcd.clear();
        lcd.setCursor(0, 0);
        lcd.print("    CAUTION!    ");
        lcd.setCursor(0, 1);
        lcd.print(" LINE_1 FAULT:5 ");
      }
    }
  }
  if (!digitalRead(LINE_1_STATUS)) {
    Serial.println("[LINE1 ON]:N");
  }
  delay(1000);
  lcd.clear();
}
// CAMERA OUTPUT
// (TAG RECOGNITION)
// 1: NORMAL
// 2: FAULT1
// 3: FAULT2
// 4: FAULT3
// 5: FAULT4
// 6: FAULT5
void printResult(HUSKYLENSResult result){
  if (result.command == COMMAND_RETURN_BLOCK){
    Serial.println(String() + F("[ID]:") + result.ID);
  }
}
