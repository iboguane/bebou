
public class Cooldowns
{
    private float initialCD;
    public float currentCD;
    public bool isFinished;

    public Cooldowns(float initialTimer)
    {
        this.initialCD = initialTimer;
        currentCD = 0;
        isFinished = true;
    }

    public void DecreaseCD(float time)
    {
        if (isFinished) return;
        currentCD -= time;
        if (currentCD <= 0) isFinished = true;
    }

    public void ResetCD(float newTimer = -1)
    {
        initialCD = newTimer < 0 ? initialCD : newTimer;
        currentCD = initialCD;
        isFinished = false;
    }
}
