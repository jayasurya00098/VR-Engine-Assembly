using UnityEngine;

public class AssemblyStateManager
{
    private static AssemblyStateManager instance;
    public static AssemblyStateManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AssemblyStateManager();
            }
            return instance;
        }
    }

    private enum AssemblyState
    {
        CRANK,
        CRANK_CASE,
        PISTONS,
        CYLINDER_HEAD_LEFT,
        CYLINDER_HEAD_RIGHT,
        ROCKERARMS,
        ENGINE_SIDE,
        ENGINE_SIDE_TUBE,
        AIRFILTER,
        TUBE_FITTING,
        OIL_PAN,
        MAINFOLD,
        ENGINE_COVER_LEFT,
        BIG_BOLTS_LEFT,
        BOLTS_LEFT,
        ENGINE_COVER_RIGHT,
        BIG_BOLTS_RIGHT,
        BOLTS_RIGHT,
        COMPLETED
    }
    private AssemblyState states;

    private int numberOfPistons = 0;
    private int numberOfRockers = 0;
    private int totalPistons = 8;
    private int totalRockers = 16;

    private int numberOfBigBolts = 0;
    private int numberOfBolts = 0;
    private int totalBigBolts = 2;
    private int totalBolts = 3;

    public int CurrentState()
    {
        return (int)states;
    }

    public void SwitchState(int state)
    {
        switch (state)
        {
            default:
                Debug.Log("Default");
                break;
            case 0:
                Debug.Log("State " + state);
                states = (AssemblyState)state;
                break;
            case 1:
                Debug.Log("State " + state);
                states = (AssemblyState)state;
                break;
            case 2:
                Debug.Log("State " + state);
                numberOfPistons++;
                if(totalPistons == numberOfPistons)
                {
                    states = (AssemblyState)state;
                }
                break;
            case 3:
                Debug.Log("State " + state);
                states = (AssemblyState)state;
                break;
            case 4:
                Debug.Log("State " + state);
                states = (AssemblyState)state;
                break;
            case 5:
                Debug.Log("State " + state);
                numberOfRockers++;
                if(totalRockers == numberOfRockers)
                {
                    states = (AssemblyState)state;
                }
                break;
            case 6:
                Debug.Log("State " + state);
                states = (AssemblyState)state;
                break;
            case 7:
                Debug.Log("State " + state);
                states = (AssemblyState)state;
                break;
            case 8:
                Debug.Log("State " + state);
                states = (AssemblyState)state;
                break;
            case 9:
                Debug.Log("State " + state);
                states = (AssemblyState)state;
                break;
            case 10:
                Debug.Log("State " + state);
                states = (AssemblyState)state;
                break;
            case 11:
                Debug.Log("State " + state);
                states = (AssemblyState)state;
                break;
            case 12:
                Debug.Log("State " + state);
                states = (AssemblyState)state;
                break;
            case 13:
                Debug.Log("State " + state);
                numberOfBigBolts++;
                if(totalBigBolts == numberOfBigBolts)
                {
                    numberOfBigBolts = 0;
                    states = (AssemblyState)state;
                }
                break;
            case 14:
                Debug.Log("State " + state);
                numberOfBolts++;
                if(totalBolts == numberOfBolts)
                {
                    numberOfBolts = 0;
                    states = (AssemblyState)state;
                }
                break;
            case 15:
                Debug.Log("State " + state);
                states = (AssemblyState)state;
                break;
            case 16:
                Debug.Log("State " + state);
                numberOfBigBolts++;
                if (totalBigBolts == numberOfBigBolts)
                {
                    numberOfBigBolts = 0;
                    states = (AssemblyState)state;
                }
                break;
            case 17:
                Debug.Log("State " + state);
                numberOfBolts++;
                if (totalBolts == numberOfBolts)
                {
                    numberOfBolts = 0;
                    states = (AssemblyState)state;
                }
                break;
            case 18:
                Debug.Log("Assembly Completed");
                break;

        }
    }
}
