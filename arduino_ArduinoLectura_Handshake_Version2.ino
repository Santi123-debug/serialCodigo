// ArduinoLectura_Handshake.ino
// Arduino Uno: espera handshake 'S' desde la app PC antes de empezar a enviar lecturas.

const int sensorPin = A0;
const unsigned long intervaloMs = 100;

void setup() {
  Serial.begin(9600);
  delay(2000); // da tiempo al PC a abrir el puerto y provocar el reinicio
  unsigned long start = millis();
  while (millis() - start < 5000) {
    if (Serial.available()) {
      char c = (char)Serial.read();
      if (c == 'S') break;
    }
  }
}

void loop() {
  int valor = analogRead(sensorPin);
  Serial.println(valor);
  delay(intervaloMs);
}