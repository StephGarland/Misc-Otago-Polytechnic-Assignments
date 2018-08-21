package com.peruvianspanishessentials.stephanie.peruvianspanishessentials;

import android.content.Intent;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.media.MediaPlayer;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.RadioGroup;

/*
 * The Question Activity/Class. Co-ordinates event logic with display
 */
public class Question extends ActionBarActivity implements View.OnClickListener{

    private MediaPlayer questionSound;
    private MediaPlayer radio1Sound;
    private MediaPlayer radio2Sound;
    private MediaPlayer radio3Sound;
    private ImageView imageView;
    private ImageButton faceButton;
    private Button nextButton;
    private Button checkAnswerButton;
    private ImageButton playQuestionSound;
    private ImageButton playRadio1Sound;
    private ImageButton playRadio2Sound;
    private ImageButton playRadio3Sound;
    private RadioButton[] radioButton;
    private int questionN;
    private int currentAnswerSelection;
    private int green;
    private int blue;
    private int totalMeritScore;
    private int totalScore;
    private boolean meritAchieved;
    private boolean passAchieved;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_question);

        //gets the question selection from the home activity and saves it as questionN
        Bundle extras = getIntent().getExtras();
        //questionN = 0;
        if (extras != null)
        {
            questionN = extras.getInt("button pushed");
        }

        totalScore = 0;
        totalMeritScore = 0;

        findViews();
        //inputs the layout variables for the selected question
        setLayoutVariables();

        green = Color.parseColor("#3D3DCC");
        blue = Color.parseColor("#1A1AC9");

    }

    //gets a java representation of the various views needed from the question layout
    public void findViews()
    {
        checkAnswerButton = (Button)findViewById(R.id.button);
        checkAnswerButton.setOnClickListener(this);
        nextButton = (Button)findViewById(R.id.button2);
        nextButton.setOnClickListener(this);
        //nextButton.setClickable(false);

        //gets a java representation of the radiobuttons
        imageView = (ImageView)findViewById(R.id.questionImage);
        faceButton = (ImageButton)findViewById(R.id.questionSpeakerButton);

        playQuestionSound = (ImageButton)findViewById(R.id.questionSpeakerButton);
        playQuestionSound.setOnClickListener(this);
        playRadio1Sound = (ImageButton)findViewById(R.id.phraseSpeakerButton);
        playRadio1Sound.setOnClickListener(this);
        playRadio2Sound = (ImageButton)findViewById(R.id.phrase2SpeakerButton);
        playRadio2Sound.setOnClickListener(this);
        playRadio3Sound = (ImageButton)findViewById(R.id.phrase3SpeakerButton);
        playRadio3Sound.setOnClickListener(this);

        radioButton = new RadioButton[3];
        radioButton[0] = (RadioButton)findViewById(R.id.radioButton);
        radioButton[0].setOnClickListener(this);
        radioButton[1] = (RadioButton)findViewById(R.id.radioButton2);
        radioButton[1].setOnClickListener(this);
        radioButton[2] = (RadioButton)findViewById(R.id.radioButton3);
        radioButton[2].setOnClickListener(this);
    }

    //Gets the variables specific to the current question and loads them into the layout components
    public void setLayoutVariables()
    {
        //sets the display image based on question number
        imageView.setImageResource(QuestionSet.getQuestionSet()[questionN].getImage());
        questionSound = MediaPlayer.create(this, QuestionSet.getQuestionSet()[questionN].getQuestionSound());
        radio1Sound = MediaPlayer.create(this, QuestionSet.getQuestionSet()[questionN].getQuestionOptionSound()[0]);
        radio2Sound = MediaPlayer.create(this, QuestionSet.getQuestionSet()[questionN].getQuestionOptionSound()[1]);
        radio3Sound = MediaPlayer.create(this, QuestionSet.getQuestionSet()[questionN].getQuestionOptionSound()[2]);

        meritAchieved = false;
        passAchieved = false;
        //sets the phrase options based on question number
        for (int i = 0; i < radioButton.length; i++)
        {
            radioButton[i].setText(QuestionSet.getQuestionSet()[questionN].getQuestionOption()[i]);
        }

        faceButton.setImageResource(R.drawable.speaker100);
        //faceButton.setBackground();
        disableNextButton();
    }

    //disables the next button
    public void disableNextButton()
    {
        nextButton.setClickable(false);
        nextButton.getBackground().setColorFilter(Color.LTGRAY, PorterDuff.Mode.MULTIPLY);
        nextButton.setTextColor(Color.GRAY);
    }

    //enables the next button
    public void enableNextButton()
    {
        nextButton.setClickable(true);
        nextButton.getBackground().setColorFilter(Color.GREEN, PorterDuff.Mode.MULTIPLY);
        nextButton.setTextColor(Color.BLACK);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_question, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up checkAnswerButton, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onClick(View view) {
        int id = view.getId();
        switch (id) {
            case R.id.button:
                checkAnswer();
            break;
            case R.id.button2:
                calulateScoreForQuestion();
                break;
            case R.id.radioButton:
                customRadioButtonDeselect();
                currentAnswerSelection = 0;
                customRadioButtonSelect();
                break;
            case R.id.radioButton2:
                customRadioButtonDeselect();
                currentAnswerSelection = 1;
                customRadioButtonSelect();
                break;
            case R.id.radioButton3:
                customRadioButtonDeselect();
                currentAnswerSelection = 2;
                customRadioButtonSelect();
                break;
            case R.id.questionSpeakerButton:
                questionSound.start();
                break;
            case R.id.phraseSpeakerButton:
                radio1Sound.start();
                break;
            case R.id.phrase2SpeakerButton:
                radio2Sound.start();
                break;
            case R.id.phrase3SpeakerButton:
                radio3Sound.start();
                break;
            default:
                break;
        }
    }


    //calculates a score for the current question
    public void calulateScoreForQuestion()
    {
        if(meritAchieved)
        {
            totalMeritScore++;
        }
        if(passAchieved)
        {
            totalScore++;
        }
        if(questionN < QuestionSet.getQuestionSet().length - 1) {
            questionN++;
            setLayoutVariables();
        }
        else
        {
            Intent intent = new Intent(this, Score.class);
            intent.putExtra("total score", totalScore);
            intent.putExtra("total merit score", totalMeritScore);
            startActivity(intent);
            //checkAnswerButton.setText("" + totalScore + " and " + totalMeritScore);
        }
    }

    //deselects and dehighlights a radiobutton
    public void customRadioButtonDeselect()
    {
        radioButton[currentAnswerSelection].setChecked(false);
        radioButton[currentAnswerSelection].setBackgroundColor(blue);
        currentAnswerSelection = 0;
    }

    //selects and highlights a radiobutton
    public void customRadioButtonSelect()
    {
        radioButton[currentAnswerSelection].setChecked(true);
        radioButton[currentAnswerSelection].setBackgroundColor(green);
    }

    //checks for feedback on a submitted answer
    public void checkAnswer()
    {
        int feedback;

        String answer = radioButton[currentAnswerSelection].getText().toString();

        if(currentAnswerSelection <= radioButton.length) {
            feedback = QuestionSet.getQuestionSet()[questionN].determineFeedback(answer);
            //checkAnswerButton.setText("" + feedback);
            displayFeedback(feedback);
        }
        //make a display decision based on feedback.

    }

    //sets the feedback display of views
    public void displayFeedback(int feedback)
    {
        faceButton.setBackground(null);
        //android:background="@null"
        switch(feedback)
        {
            case 0:
                meritAchieved = true;
                passAchieved = true;
                faceButton.setImageResource(R.drawable.smiling29);
                enableNextButton();
                break;
            case 1:
                passAchieved = true;
                faceButton.setImageResource(R.drawable.doubt2);
                enableNextButton();
                break;
            case 2:
                faceButton.setImageResource(R.drawable.anger4);
                disableNextButton();
                break;
            default:
                break;
        }
    }

}
