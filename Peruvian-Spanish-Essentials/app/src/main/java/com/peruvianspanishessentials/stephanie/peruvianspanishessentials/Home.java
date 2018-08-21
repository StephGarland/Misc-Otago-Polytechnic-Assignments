package com.peruvianspanishessentials.stephanie.peruvianspanishessentials;

/*=============================================================================
        |   Assignment:  Java Android App
        |
        |       Author:  Stephanie Garland
        |     Language:  Java, Android Studio
        |
        |        Class:  Java (Programming 3)
        |   Instructor:  Dale Parsons
        |     Due Date:  19.06.2015
        |
        +-----------------------------------------------------------------------------
        |
        |  Description: An app that follows a quiz structure in order to familarise
        |       users with basic spanish phrases for tourists.
        |
        |   Known Bugs:  Some intended functionality partially in place:
        |                   - Sound recordings for phrase options
        |                   - Home screen showing an overview of all questions
        |                   - English translations of phrases not currently viewable
        |
        *============================================================================*/

import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;

import java.util.ArrayList;

/**
 * Creates and fills a question set: an array of type QuestionInformation
 */
public class Home extends ActionBarActivity {

    //private int buttonPushed;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_home, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    public void openQuestion(View view)
    {
        int buttonPushed = 99;
        int id = view.getId();
        switch (id) {
            case R.id.section1Button:
            case R.id.question1Button:
                buttonPushed = 0;
                break;
            case R.id.question2Button:
                buttonPushed = 1;
                break;
            case R.id.question3Button:
                buttonPushed = 2;
                break;
            case R.id.section2Button:
            case R.id.question4Button:
                buttonPushed = 3;
                break;
            case R.id.question5Button:
                buttonPushed = 4;
                break;
            case R.id.question6Button:
                buttonPushed = 5;
                break;
            case R.id.section3Button:
            case R.id.question7Button:
                buttonPushed = 6;
                break;
            case R.id.question8Button:
                buttonPushed = 7;
                break;
            case R.id.question9Button:
                buttonPushed = 8;
                break;
            default:
                break;
        }

        Intent intent = new Intent(this, Question.class);
        intent.putExtra("button pushed", buttonPushed);
        startActivity(intent);

    }
}
