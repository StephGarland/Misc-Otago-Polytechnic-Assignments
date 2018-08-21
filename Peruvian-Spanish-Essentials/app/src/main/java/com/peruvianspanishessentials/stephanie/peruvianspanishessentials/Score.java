package com.peruvianspanishessentials.stephanie.peruvianspanishessentials;

import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

/*
 * The Score class: calculates and displays the overall score
 */
public class Score extends ActionBarActivity implements View.OnClickListener{

    private int totalScore;
    private int totalMeritScore;
    private TextView tvDisplayScore;
    private Button homeButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_score);

        Bundle extras = getIntent().getExtras();
        //questionN = 0;
        if (extras != null)
        {
            totalScore = extras.getInt("total score");
            totalMeritScore = extras.getInt("total merit score");
        }

        tvDisplayScore = (TextView)findViewById(R.id.tvResults);
        homeButton = (Button)findViewById(R.id.homeButton);
        homeButton.setOnClickListener(this);

        int nImprovements = totalScore - totalMeritScore;

        String result;
        if (nImprovements != 0) {
            result = "Good job! You gave a passable answer to all questions!" +
                     "\nThere were " + nImprovements + " answers you could improve on though -\n" +
                     "Would you like to try again?";
        }
        else
        {
            result = "Good job! You gave perfect answers to all questions -\n" +
                     "You're a spanish expert!\nWould you like to practice some more?";
        }
        tvDisplayScore.setText(result);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_score, menu);
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

    @Override
    public void onClick(View view) {
        int id = view.getId();
        switch (id) {
            case R.id.homeButton:
                Intent intent = new Intent(this, Question.class);
                startActivity(intent);
                break;
            default:
                break;
        }
    }
}
