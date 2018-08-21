package com.peruvianspanishessentials.stephanie.peruvianspanishessentials;

import android.widget.RadioButton;

import java.util.Random;

/*
 * The Question class: contains gets/sets for each question specfic variable
 */
public class QuestionInformation {

    private int image;
    private int questionSound;
    private RadioButton[] radioBox;
    private String[] questionOption;
    private int[] questionOptionSound;
    private String question;
    private String meritAnswer;
    private String passAnswer;
    private String failAnswer;
    //private bool questionComplete;

    public QuestionInformation(int image, String[] questionOption, int[] questionOptionSound, String question, int questionSound)
    {
        this.setImage(image);
        this.setQuestionOption(questionOption);
        this.setQuestionOptionSound(questionOptionSound);
        this.setQuestionSound(questionSound);

        //record the level of correctness of question specific answers
        meritAnswer = questionOption[0];
        passAnswer = questionOption[1];
        failAnswer = questionOption[2];

        shuffleArray(questionOption);
    }

    public void shuffleArray(String[] array)
    {
        Random random = new Random();
        for (int i = array.length - 1; i > 0; i--)
        {
            int index = random.nextInt(i + 1);
            // Simple swap
            String a = array[index];
            array[index] = array[i];
            array[i] = a;
        }
    }

//    public void setLayoutVariables(ImageView imageView, RadioButton[] radioButtons)
//    {
//        //set the question specific image
//        //imageView.setImageResource(getImage());
//
//        //shuffle answers
//        //shuffleArray(questionOption);
//
//        //assign answers to radioboxes
//
//        for (int i = 0; i < radioButtons.length; i++)
//        {
//            radioButtons[i].setText(getQuestionOption()[i]);
//        }
//    }

    public int determineFeedback(String givenAnswer)
    {
        int feedback;

        if (givenAnswer == meritAnswer)
        {
            feedback = 0;
        }
        else if (givenAnswer == passAnswer)
        {
            feedback = 1;
        }
        else
        {
            feedback = 2;
        }
        return feedback;

       // if (correctAnswer ==
    }

    public int getImage() {
        return image;
    }

    public void setImage(int image) {
        this.image = image;
    }

    public String[] getQuestionOption() {
        return questionOption;
    }

    public void setQuestionOption(String[] questionOption) {
        this.questionOption = questionOption;
    }

    public int getQuestionSound() {
        return questionSound;
    }

    public void setQuestionSound(int questionSound) {
        this.questionSound = questionSound;
    }

    public int[] getQuestionOptionSound() {
        return questionOptionSound;
    }

    public void setQuestionOptionSound(int[] questionOptionSound) {
        this.questionOptionSound = questionOptionSound;
    }
    //question imageView
    //question sound
    //three different options: radiobox x3
    //three different options sounds
    //correct answer
    //bool question completed > tells home icon to change colour
}
