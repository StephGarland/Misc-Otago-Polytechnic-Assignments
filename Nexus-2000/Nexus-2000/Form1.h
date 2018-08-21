//////////////////////////////////////////////////////////////////
//																//
//	Program name:	Nexus 2000									//
//  Author:			Steph Garland								//
//	Repo link:		https://github.com/StephGarland/Nexus-2000	//
//																//
//	Language:		Managed C++									//
//	IDE:			Microsoft Visual Studio 2008				//
//	Last modified:	21/10/15									//
//																//
//	Description:	Simulation of the game Nexus 2000			//
//	Known Bugs:		None.										//
//																//
//////////////////////////////////////////////////////////////////
#pragma once
#include "GameCoordinator.h"

namespace Nexus2000 {

	using namespace System;
	using namespace System::IO;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	/// The entry point to the application. Handles user input and form component properties.
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();

			//sound initialisation and settings.
			backgroundTrack = gcnew WMPLib::WindowsMediaPlayer();
			backgroundTrack->settings->setMode("loop", true);
			//song taken from https://www.youtube.com/watch?v=QNwCojCJ3-Q
			backgroundTrack->URL = "MEOW.mp3";
			backgroundTrack->settings->volume::set(12);
			backgroundTrack->controls->stop();

			soundFX = gcnew array<WMPLib::WindowsMediaPlayer^>(3);
			WMPLib::WindowsMediaPlayer^ happyTrack = gcnew WMPLib::WindowsMediaPlayer();
			happyTrack->URL = "happyCat.mp3";
	        happyTrack->controls->stop();
			soundFX[0] = happyTrack;

			WMPLib::WindowsMediaPlayer^ angryTrack = gcnew WMPLib::WindowsMediaPlayer();
			angryTrack->URL = "angryCat.mp3";
			angryTrack->controls->stop();
			soundFX[1] = angryTrack;

			WMPLib::WindowsMediaPlayer^ movementTrack = gcnew WMPLib::WindowsMediaPlayer();
			movementTrack->URL = "footstep.mp3";
			movementTrack->settings->volume::set(100);
			movementTrack->controls->stop();
			soundFX[2] = movementTrack;

			try{
				mute = Image::FromFile("mute.png");
			}catch(IOException^ e){}
			try{
				sound = Image::FromFile("sound.png");
			}catch(IOException^ e){}

			currentGame = gcnew GameCoordinator(soundFX);
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}

	Image^ mute;
	Image^ sound;
	WMPLib::WindowsMediaPlayer^ backgroundTrack;
	array<WMPLib::WindowsMediaPlayer^>^ soundFX;

	private: System::Windows::Forms::PictureBox^  pb_Grid;
	private: System::Windows::Forms::Label^  lbl_currentScore;
	private: System::Windows::Forms::Label^  lbl_highScore;
	private: System::Windows::Forms::Button^  btn_undo;
	private: System::Windows::Forms::Button^  btn_Start;
	private: System::Windows::Forms::Timer^  timer1;
	private: System::ComponentModel::IContainer^  components;
	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::CheckBox^  cb_Sound;


			 GameCoordinator^ currentGame;


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
			this->pb_Grid = (gcnew System::Windows::Forms::PictureBox());
			this->lbl_currentScore = (gcnew System::Windows::Forms::Label());
			this->lbl_highScore = (gcnew System::Windows::Forms::Label());
			this->btn_undo = (gcnew System::Windows::Forms::Button());
			this->btn_Start = (gcnew System::Windows::Forms::Button());
			this->timer1 = (gcnew System::Windows::Forms::Timer(this->components));
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->cb_Sound = (gcnew System::Windows::Forms::CheckBox());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pb_Grid))->BeginInit();
			this->SuspendLayout();
			// 
			// pb_Grid
			// 
			this->pb_Grid->BackColor = System::Drawing::Color::Transparent;
			this->pb_Grid->Location = System::Drawing::Point(1, 31);
			this->pb_Grid->Name = L"pb_Grid";
			this->pb_Grid->Size = System::Drawing::Size(332, 326);
			this->pb_Grid->TabIndex = 0;
			this->pb_Grid->TabStop = false;
			this->pb_Grid->MouseClick += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pb_Grid_MouseClick);
			this->pb_Grid->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &Form1::pb_Grid_Paint);
			// 
			// lbl_currentScore
			// 
			this->lbl_currentScore->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->lbl_currentScore->Location = System::Drawing::Point(98, 2);
			this->lbl_currentScore->Name = L"lbl_currentScore";
			this->lbl_currentScore->Size = System::Drawing::Size(75, 28);
			this->lbl_currentScore->TabIndex = 1;
			this->lbl_currentScore->Text = L"00000";
			this->lbl_currentScore->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// lbl_highScore
			// 
			this->lbl_highScore->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->lbl_highScore->ForeColor = System::Drawing::SystemColors::ControlDark;
			this->lbl_highScore->Location = System::Drawing::Point(247, 2);
			this->lbl_highScore->Name = L"lbl_highScore";
			this->lbl_highScore->Size = System::Drawing::Size(75, 28);
			this->lbl_highScore->TabIndex = 2;
			this->lbl_highScore->Text = L"00000";
			this->lbl_highScore->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// btn_undo
			// 
			this->btn_undo->BackColor = System::Drawing::Color::Black;
			this->btn_undo->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"btn_undo.BackgroundImage")));
			this->btn_undo->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Zoom;
			this->btn_undo->FlatStyle = System::Windows::Forms::FlatStyle::Popup;
			this->btn_undo->Location = System::Drawing::Point(179, 4);
			this->btn_undo->Name = L"btn_undo";
			this->btn_undo->Size = System::Drawing::Size(28, 25);
			this->btn_undo->TabIndex = 3;
			this->btn_undo->UseVisualStyleBackColor = false;
			this->btn_undo->Click += gcnew System::EventHandler(this, &Form1::btn_undo_Click);
			// 
			// btn_Start
			// 
			this->btn_Start->Location = System::Drawing::Point(1, 2);
			this->btn_Start->Name = L"btn_Start";
			this->btn_Start->Size = System::Drawing::Size(59, 28);
			this->btn_Start->TabIndex = 4;
			this->btn_Start->Text = L"Start";
			this->btn_Start->UseVisualStyleBackColor = true;
			this->btn_Start->Click += gcnew System::EventHandler(this, &Form1::btn_Start_Click);
			// 
			// timer1
			// 
			this->timer1->Tick += gcnew System::EventHandler(this, &Form1::timer1_Tick);
			// 
			// button1
			// 
			this->button1->BackColor = System::Drawing::Color::Black;
			this->button1->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button1.BackgroundImage")));
			this->button1->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Zoom;
			this->button1->FlatStyle = System::Windows::Forms::FlatStyle::Popup;
			this->button1->Location = System::Drawing::Point(213, 4);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(28, 25);
			this->button1->TabIndex = 6;
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// cb_Sound
			// 
			this->cb_Sound->Appearance = System::Windows::Forms::Appearance::Button;
			this->cb_Sound->BackColor = System::Drawing::Color::Black;
			this->cb_Sound->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"cb_Sound.BackgroundImage")));
			this->cb_Sound->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Zoom;
			this->cb_Sound->Checked = true;
			this->cb_Sound->CheckState = System::Windows::Forms::CheckState::Checked;
			this->cb_Sound->FlatStyle = System::Windows::Forms::FlatStyle::Popup;
			this->cb_Sound->ForeColor = System::Drawing::Color::Black;
			this->cb_Sound->Location = System::Drawing::Point(64, 4);
			this->cb_Sound->Name = L"cb_Sound";
			this->cb_Sound->Size = System::Drawing::Size(28, 25);
			this->cb_Sound->TabIndex = 7;
			this->cb_Sound->UseVisualStyleBackColor = false;
			this->cb_Sound->CheckedChanged += gcnew System::EventHandler(this, &Form1::cb_Sound_CheckedChanged);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"$this.BackgroundImage")));
			this->ClientSize = System::Drawing::Size(325, 355);
			this->Controls->Add(this->cb_Sound);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->btn_Start);
			this->Controls->Add(this->btn_undo);
			this->Controls->Add(this->lbl_highScore);
			this->Controls->Add(this->lbl_currentScore);
			this->Controls->Add(this->pb_Grid);
			this->Icon = (cli::safe_cast<System::Drawing::Icon^  >(resources->GetObject(L"$this.Icon")));
			this->Name = L"Form1";
			this->Text = L"Nexus 2000";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pb_Grid))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion
	///
	///The paint event for the main picturebox grid
	///
	private: System::Void pb_Grid_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) 
			 {
				 currentGame->Draw(e->Graphics);
			 }			

   ///
   ///Prompts actions that need to be repeated every timer interval. Sets the pace of the game.
   ///
	private: System::Void timer1_Tick(System::Object^  sender, System::EventArgs^  e) {
				 bool gameOver = currentGame->Update();
				 if(gameOver)
				 {
					 soundFX[1]->controls->play();
					 MessageBox::Show("GAME OVER MAN, GAME OVER");
				 }

				 int score = currentGame->GetScore();
				 lbl_currentScore->Text = score.ToString("D5");
				 pb_Grid->Invalidate();
			 }

  	///
	/// The on click event for the undo button. Allows a user to undo the last move made.
	///
	private: System::Void btn_undo_Click(System::Object^  sender, System::EventArgs^  e) {
				 currentGame->Undo();
			 }

	///
	/// The on click event for the start button. Prompts a new game to begin.
	///
	private: System::Void btn_Start_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->timer1->Enabled = true;
			 currentGame = gcnew GameCoordinator(soundFX);
			 currentGame->Start();
			 this->btn_Start->Text = "Restart";
			 lbl_highScore->Text = currentGame->ReadScore().ToString("D5");

			 if(cb_Sound->Checked == true)
			 {
				backgroundTrack->controls->play();
			 }
		 }

	///
	/// Saves the pixel location of a click within the grid.
	///
	private: System::Void pb_Grid_MouseClick(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
				 Point^ clickLocation = gcnew Point(e->X, e->Y);
				 currentGame->ClickLocation(clickLocation);
			 }

	///
	/// The on click event for the redo button. Allows a user to redo an undo just made.
	///
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
				 currentGame->Redo();
			 }

	///
	/// Triggered when the sound checkbox is toggled. Mutes/plays background song.
	///
	private: System::Void cb_Sound_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
			 		if (cb_Sound->Checked)
					 {
						 backgroundTrack->controls->play();
						 cb_Sound->BackgroundImage::set(sound);				 
					 }
					 else
					 {
						 backgroundTrack->controls->pause();
						 cb_Sound->BackgroundImage::set(mute);
					 }
			 }
};
}

