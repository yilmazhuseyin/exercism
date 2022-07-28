using System;

static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake)
    {
        return !knightIsAwake;
    }

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
    {
        return ((knightIsAwake || archerIsAwake) || prisonerIsAwake) ? true : false;
    }

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
    {
        return (!archerIsAwake && prisonerIsAwake) ? true : false;
    }

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
    {
        if((!knightIsAwake && archerIsAwake) && ((!prisonerIsAwake && petDogIsPresent) || (prisonerIsAwake && petDogIsPresent) || (prisonerIsAwake && !petDogIsPresent)) )
            return false;

        if(knightIsAwake  && !archerIsAwake && prisonerIsAwake && !petDogIsPresent)
            return false;
        
        return (((!knightIsAwake && !archerIsAwake) || (knightIsAwake && !archerIsAwake) || (!knightIsAwake && archerIsAwake)) && ((!prisonerIsAwake && petDogIsPresent) || (prisonerIsAwake && petDogIsPresent) || (prisonerIsAwake && !petDogIsPresent))) ? true : false;
    }
}
