#pragma once
#include "GameGrid.h"

namespace Tetris {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;



	/// <summary>
	/// Summary for Form1
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
			//
			//TODO: Add the constructor code here
			//
			graphics = CreateGraphics();
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
	private: System::Windows::Forms::Panel^  panel1;
			 Graphics^ graphics;
			 GameGrid^ grid;

	private: System::Windows::Forms::Timer^  timer1;
	private: System::ComponentModel::IContainer^  components;
	protected: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->timer1 = (gcnew System::Windows::Forms::Timer(this->components));
			this->SuspendLayout();
			// 
			// panel1
			// 
			this->panel1->BorderStyle = BorderStyle::FixedSingle;
			this->panel1->Location = System::Drawing::Point(25, 25);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(0, 0);
			this->panel1->TabIndex = 0;
			this->panel1->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &Form1::panel1_Paint);
			// 
			// timer1
			// 
			this->timer1->Enabled = true;
			this->timer1->Interval = 1000;
			this->timer1->Tick += gcnew System::EventHandler(this, &Form1::timer1_Tick);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::White;
			this->ClientSize = System::Drawing::Size(385, 330);
			this->Controls->Add(this->panel1);
			this->DoubleBuffered = true;
			this->Name = L"Form1";
			this->Text = L"Tetris";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &Form1::Form1_KeyDown);
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void panel1_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) 
			 {
				grid->Draw(e->Graphics);
			 }
	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) 
			 {	
				 grid = gcnew GameGrid(graphics);
				 this->panel1->Size = System::Drawing::Size(grid->GetGridWidth(), grid->GetGridHeight());
			 }
	private: System::Void Form1_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) 
			 {
				 Direction direction;

				 switch(e->KeyCode)
				 {
					case Keys::Left:
					case Keys::A:
						direction = Direction::Left;
					break;
					case Keys::Right:
					case Keys::D:
						direction = Direction::Right;
					break;
					case Keys::Enter:
					case Keys::Space:
					case Keys::Down:
					case Keys::S:
						direction = Direction::Down;
					break;
					case Keys::Up:
					case Keys::Z:
					case Keys::X:
						direction = Direction::Up;
					break;
				 }

			    grid->MoveShape(direction);
				panel1->Invalidate();

			 }
	private: System::Void timer1_Tick(System::Object^  sender, System::EventArgs^  e) {
				 grid->Update();
				 panel1->Invalidate();
			 }
};
}

