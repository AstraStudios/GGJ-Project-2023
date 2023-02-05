using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantLSystem : MonoBehaviour
{
    public GameObject lineDrawer;
    private DrawLine drawLineScript;

    // the starting word
    public string startWord = "F";

    // how many times it should run
    public int recursionLevel;
    public int currentRecusrionLevel;

    // because there is no serilized feild for dictionary, just define replacements for F
    public Dictionary<string, string> productions = new Dictionary<string, string>();
    public string FReplacement = "F";

    // drawing instructions
    public float angleChange = 20f;
    public float distanceChange = 2f;
    public float startAngle = 90f;

    // size of tree
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;


    private string derive(string word, Dictionary<string, string> productions, int recursionLevel)
    {
        // the word generated after each derivation. set it to word incase there are no runs
        string new_word = word;

        for (int i = 0; i < recursionLevel; i++)
        {
            new_word = "";

            // run each letter through
            for (int letterIndex = 0; letterIndex < word.Length; letterIndex++)
            {
                string letter = word[letterIndex].ToString();

                // if the productions dont specify what to do
                if (!productions.ContainsKey(letter))
                {
                    new_word += letter;
                    continue;
                }

                // add the production to the new word
                new_word += productions[letter];
            }

            word = new_word;
        }

        return new_word;
    }

    public void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject line = Instantiate(lineDrawer, new Vector3(0, 0, 0), Quaternion.identity);

        drawLineScript = line.GetComponent<DrawLine>();
        drawLineScript.start = new Vector3(start.x, start.y, 0);
        drawLineScript.end = new Vector3(end.x, end.y, 0);

        line.transform.parent = gameObject.transform;
    }

    // this will simulate a basic turtle program creating lines
    private void DrawString(string word, float angleChange, float distanceChange, float startx, float starty, float startangle)
    {
        // state of the turtle (x, y, angle)
        Vector3 state = new Vector3(startx, starty, startangle);

        List<Vector3> savedStatesStack = new List<Vector3>();

        // move the turtle forwards and draw a line
        void TurtleForward(float distance)
        {
            // save the start
            Vector3 start = state;
            float angle = state.z;

            // change state
            state.x += Mathf.Round(distance * Mathf.Cos(Mathf.Deg2Rad * angle));
            state.y += Mathf.Round(distance * Mathf.Sin(Mathf.Deg2Rad * angle));

            // draw the line
            DrawLine(start, state);
        }

        // change the angle of the turtle
        void TurtleTurn(float angle)
        {
            state.z += angle;
        }

        // for each letter run a command:
        // F   - forward and draw
        // -/+ - turn left/right
        // [/] - save/load state to/from stack
        for (int letterIndex = 0; letterIndex < word.Length; letterIndex++)
        {
            string letter = word[letterIndex].ToString();
            if (letter == "F")
                TurtleForward(distanceChange);
            if (letter == "-")
                TurtleTurn(angleChange);
            if (letter == "+")
                TurtleTurn(-angleChange);
            if (letter == "[")
                savedStatesStack.Add(state);
            if (letter == "]")
            {
                // get the last item in the stack, set the state to it and pop it
                int lastIndex = savedStatesStack.Count - 1;
                state = savedStatesStack[lastIndex];
                savedStatesStack.RemoveAt(lastIndex);
            }

            // redifine the size
            if (state.x > maxX) maxX = state.x;
            if (state.y > maxY) maxY = state.y;
            if (state.x < minX) minX = state.x;
            if (state.y < minY) minX = state.y;
        }
    }

    // generate a plant
    public void Generate(int recursionLevel)
    {
        currentRecusrionLevel = recursionLevel;

        // generate the turtle commands
        string word = derive(startWord, productions, recursionLevel);

        // draw the tree at the position of the object
        DrawString(word, angleChange, distanceChange, gameObject.transform.position.x, gameObject.transform.position.y, startAngle);
    }

    // setup productions and make the tree
    private void Start()
    {
        productions.Add("F", FReplacement);

        Generate(recursionLevel);
    }
}
