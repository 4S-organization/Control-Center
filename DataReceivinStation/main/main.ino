#include <SoftwareSerial.h>

#define RX 8
#define TX 9

SoftwareSerial HC12(RX,TX);

void setup() {
  Serial.begin(9600);
  HC12.begin(9600);
}
bool authorized = false;
String line = "";
void loop() {
  if(authorized){
  /*if(HC12.available()){
    if (HC12.read() == 0xAA){
      Serial.println('1');
    } else {
      Serial.println('0');
    }
  }*/}
  else{
    if(Serial.available()){
      char letter = Serial.read();
      if(letter == '\n'){
        if(line=="okconnected"){
          authorized = true;
         }else{
          line = "";
          }
       }else{
        line+=letter;
        }
    }else{
      Serial.print("Four Slaves\n");
      }
    }
  }
