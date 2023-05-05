namespace Sem5.EventBus
{
    public delegate void StartRaceHandler();

    public delegate void FinishRaceHandler();

    public delegate void TrackTimeUpdateHandler(float trackTime);

}