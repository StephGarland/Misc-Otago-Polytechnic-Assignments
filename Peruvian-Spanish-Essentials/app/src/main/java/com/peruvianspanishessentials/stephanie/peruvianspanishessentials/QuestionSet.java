package com.peruvianspanishessentials.stephanie.peruvianspanishessentials;

/**
 * Creates and fills a question set: an array of type QuestionInformation
 */
public class QuestionSet {

    private static final QuestionInformation[] questionSet = createQuestions();

    public static QuestionInformation[] createQuestions()
    {
        ///////////////////////
        QuestionInformation[] questionSet = new QuestionInformation[9];
        ///////////////////////

        String question1 = "Hola";
        String[] question1answers = new String[3];
        question1answers[0] = "Hola";
        question1answers[1] = "Hablas inglés?";
        question1answers[2] = "Adiós";

        int[] question1Sounds = new int[3];
        question1Sounds[0] = R.raw.hola;
        question1Sounds[1] = R.raw.hablas_ingles;
        question1Sounds[2] = R.raw.adios;
        int question1Sound = R.raw.hola;

        questionSet[0] = new QuestionInformation(R.drawable.man1, question1answers, question1Sounds, question1, question1Sound);

        ////////////////////////

        String question2 = "Bienvenido";
        String[] question2answers = new String[3];
        question2answers[0] = "Gracias";
        question2answers[1] = "Hablas inglés?";
        question2answers[2] = "De nada";

        int[] question2Sounds = new int[3];
        question2Sounds[0] = R.raw.hola;
        question2Sounds[1] = R.raw.hablas_ingles;
        question2Sounds[2] = R.raw.adios;
        int question2Sound = R.raw.bienvenido;

        questionSet[1] = new QuestionInformation(R.drawable.woman1, question2answers, question2Sounds, question2, question2Sound);

        ////////////////////////////

        String question3 = "Hablas inglés?";
        String[] question3answers = new String[3];
        question3answers[0] = "Sí";
        question3answers[1] = "No";
        question3answers[2] = "No sé";

        int question3Sound = R.raw.hablas_ingles;
        questionSet[2] = new QuestionInformation(R.drawable.woman3, question3answers, question2Sounds, question3, question3Sound);

        /////////////////////////////

        String question4 = "Cómo está usted?";
        String[] question4answers = new String[3];
        question4answers[0] = "Bien gracias, y usted?";
        question4answers[1] = "Bien gracias, y tú";
        question4answers[2] = "Mal.";

        int question4Sound = R.raw.como_esta_usted;

        questionSet[3] = new QuestionInformation(R.drawable.woman5, question4answers, question2Sounds, question4, question4Sound);
        /////////////////////////////

        String question5 = "Mucho gusto";
        String[] question5answers = new String[3];
        question5answers[0] = "Mucho gusto tambien";
        question5answers[1] = "Gracias";
        question5answers[2] = "Déjame en paz";

        int question5Sound = R.raw.muchogusto;

        questionSet[4] = new QuestionInformation(R.drawable.man2, question5answers, question2Sounds, question5, question5Sound);

        /////////////////////////////

        String question6 = "De donde es usted?";
        String[] question6answers = new String[3];
        question6answers[0] = "Nueva Zelanda";
        question6answers[1] = "Perú";
        question6answers[2] = "Australia";

        int question6Sound = R.raw.dedonde_es_usted;

        questionSet[5] = new QuestionInformation(R.drawable.man3, question6answers, question2Sounds, question6, question6Sound);

        /////////////////////////////

        String question7 = "Donde està el baño?";
        String[] question7answers = new String[3];
        question7answers[0] = "No lo se, lo siento";
        question7answers[1] = "No sé.";
        question7answers[2] = "Que te mejores pronto";

        int question7Sound = R.raw.donde_esta_el_bano;

        questionSet[6] = new QuestionInformation(R.drawable.man5, question7answers, question2Sounds, question7, question7Sound);

        /////////////////////////////

        String question8 = "Fuego";
        String[] question8answers = new String[3];
        question8answers[0] = "Ayúdame!";
        question8answers[1] = "Llama a la policia!";
        question8answers[2] = "No";

        int question8Sound = R.raw.fuego;

        questionSet[7] = new QuestionInformation(R.drawable.woman4, question8answers, question2Sounds, question8, question8Sound);

        /////////////////////////////

        String question9 = "Mi aerodeslizador es lleno de anguilas";
        String[] question9answers = new String[3];
        question9answers[0] = "Vale";
        question9answers[1] = "No comprendo";
        question9answers[2] = "Llama a la policia!";

        int question9Sound = R.raw.hovercraft_es;

        questionSet[8] = new QuestionInformation(R.drawable.man4, question9answers, question2Sounds, question9, question9Sound);

        /////////////////////////////
        return questionSet;
    }

    public static QuestionInformation[] getQuestionSet() {
        return questionSet;
    }
}
