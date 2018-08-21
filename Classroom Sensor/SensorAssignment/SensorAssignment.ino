#include <SD.h> //used for SD Card
#include <SPI.h> //used for SD Card
#include <DHT.h> //used for temp/humidity sensor
#include <DHT_U.h> //used for temp/humidity sensor
#include <Adafruit_Sensor.h> //used for temp/humidity sensor
#include <time.h> //used for RTC Module
#include <Wire.h> //used for RTC Module
#include <RtcDS1307.h> //used for RTC Module

//const long READING_DELAY = 900000; //15MINS
//const long READING_DELAY = 300000; //5MINS
const long READING_DELAY = 10000; //5SECS

/////////////////
//  RTC Module data:
////////////////
#define MY_TIMEZONE 1  
#define MY_TIMEZONE_IN_SECONDS (MY_TIMEZONE * ONE_HOUR)
#define myWire TwoWire
#define I2C Wire
RtcDS1307<myWire> Rtc(I2C);

/////////////////
//  SD Card data:
////////////////
int CS_PIN = 10;
File file;
const String FILE_NAME = "log.txt";

/////////////////
//  Temp/humidity sensor data:
////////////////
#define DHTPIN 2     // what pin we're connected to
#define DHTTYPE DHT22   // DHT 22  (AM2302)
DHT dht(DHTPIN, DHTTYPE); //// Initialize DHT sensor for normal 16mhz Arduino

/////////////////
//  Photo resistor data:
////////////////
const int photocellPin = 0;     // the cell and 10K pulldown are connected to a0

/////////////////
//  Begin:
////////////////
void setup()
{
    Serial.begin(9600);

    // Setup SD Card Reader/Writer
    initializeSD();
    createFile(FILE_NAME);

    // Setup Temp/Humidity sensor
    dht.begin();

    // Setup RTC
    Rtc.Begin();
    set_zone(MY_TIMEZONE_IN_SECONDS);
}

///
/// Takes a reading from each sensor and writes to file. Pauses for READING_DELAY before looping again.
///
void loop()
{     
    File_NewLine(); //Start a new line in the file

    //Get current timestamp, append:
    File_Append(currentTimeStamp());
    File_Append(",");

    //Get current humidity, append:
    float humidity = dht.readHumidity(); //read current humidity
    File_Append((String)humidity);
    File_Append(",");

    //Get current temperature, append:
    float temperature = dht.readTemperature(); //read current temperature
    File_Append((String)temperature);
    File_Append(",");

    //Get photocell reading, append:
    int photocellReading = analogRead(photocellPin); //read current light levels from photo resistor
    File_Append((String)photocellReading);    

    //Wait this amount of time before obtaining next sensor reading:
    delay(READING_DELAY); 
}

///
/// Appends the given string to the current line of the currently open file
///
void File_Append(String text) 
{
    openFile(FILE_NAME); //opens our file
    if (file) //if file exists
    {
      file.print(text); //append the given text to the current line
      Serial.print(text); //append the given text to the current serial line
      closeFile(); //close and (more importantly) save file
    } 
    else
    {
      Serial.println("Couldn't append file");
    }
}

///
/// Starts a new line in the currently open file
///
void File_NewLine()
{
    openFile(FILE_NAME); //opens our file
    if (file) //if file exists
    {
      file.println(""); //start a new line in the current file
      //In serial, add a couple of lines for nice output layout:
      Serial.println("");
      Serial.println("");
      Serial.println("New line in file created:");
      closeFile(); //close and (more importantly) save file
    } 
    else
    {
      Serial.println("Couldn't create new line in file");
    }
}

void initializeSD()
{
  Serial.println("Initializing SD card...");
  pinMode(CS_PIN, OUTPUT);

  if (SD.begin())
    Serial.println("SD card is ready to use.");
   else
    Serial.println("SD card initialization failed");
}

void createFile(String filename) //if the given filename does not exist, it will be created. If it does, it will be opened.
{
  file = SD.open(filename, FILE_WRITE);

  if (file)
    Serial.println("File created successfully.");
  else
    Serial.println("Error while creating file.");
}

void openFile(String filename)
{
    file = SD.open(filename, FILE_WRITE);
    if (!file)
        Serial.println("Error opening file...");     
}

void closeFile()
{
    if (file)      
      file.close(); //Successfully closed (and saved) file
    else
      Serial.println("Error closing file...");
}

String currentTimeStamp()
{
    char local_timestamp[20];
    time_t now = Rtc.GetTime(); 
    struct tm local_tm;
    Rtc.GetLocalTime(&local_tm);                  // GetLocalTime() compiles a "struct tm" pointer with local time
    strcpy(local_timestamp, isotime(&local_tm));  // We use the standard isotime() function to build the ISO timestamp
    return (String)local_timestamp;
}

   
