# theme: dark
# author: Hadrien Debris
VAR HP1 = 0
VAR HP2 = 0
VAR HP3 = 0
VAR HP4 = 0
VAR HP5 = 0
EXTERNAL ShowFeelingsBar(displayed)
EXTERNAL PlaySound(sound)
EXTERNAL PlayMusic(music)
EXTERNAL StopMusic()
EXTERNAL PlayAnimation(animator, animationName)
EXTERNAL EndGame(endName)
-> DEATH

=== DEATH ===

 ~ PlayMusic("bgm")
 ~ ShowFeelingsBar(true)

This morning, opening your eyes seems easier than usual, as if your eyelids were lighter. However, your head feels fuzzy. You probably overslept, needing some time to recollect your spirits but at least you are feeling refreshed. 

You rapidly understand that you are not home anymore.

You keep blinking as the landscape before you does not seem to stop changing.

A tall figure stands beside you seemingly oblivious to the large fire a few feet away.
 ~ StopMusic()
DEATH: "ARE YOU OK?"
    * [Nod]
        You acknowledge faintly.
    * "Probably..."
        The silhouette gives you time to gather your thoughts.
    * "I'm not so sure."
        The silhouette seems to understand your situation.

-   DEATH: "WHAT IS THE LAST THING YOU REMEMBER?"
Staring at the fire, you begin to remember a few things.  -> memory

=== memory ===
    *    (fire) { not object && not children } "There was a fire."
        // I THINK I CAN SEE WHERE \*THAT'S\* COMING FROM.
        DEATH: THAT'S ON ME. STARTING SLOW. AT LEAST I CAN SEE THAT YOU'RE DEMONSTRATING BASIC VISUAL ACUITY. 
        -> memory
    *   (children) "There were... children?"
        DEATH: WHAT ABOUT THEM?
            * * "Are they safe?" 
                ~HP1 = HP1 + 20
                DEATH: WELL, THEY ARE NOW. 
                -> memory
            * * "They were in danger." 
                ~HP1 = HP1 + 20
                DEATH: NOT ANYMORE. 
                -> memory
            * * "I hurt them." 
                -> hurt
    *   (object) "There was something falling from the sky!"
        DEATH: "WHAT WAS IT?"
            * * (meteorite) "A giant ball of fire."
                ~ HP1 = HP1 + 10
                DEATH: CLOSE ENOUGH. 
                -> memory
            * * (moon) "The Moon!"
                ~ HP1 = HP1 + 10
                DEATH: AREN'T YOU A BIT OVER DRAMATIC? 
                -> memory
            * * (helicopter) "It looked like... People screaming?"
                ~ HP1 = HP1 + 20
                DEATH: INDEED. 
                -> memory
    * { children } { object } ->
        DEATH: "LET ME SUM UP."
        -> story

-> memory

=== saved ===

(saved) DEATH: YES. YOU SAVED THEM. 
-> memory

=== hurt ===

DEATH: "YOU'RE RIGHT."
-> memory_failed

=== memory_failed ===

The silhouette points a bonely finger at a boat floating on what seemed to be a gravity-defying river.

DEATH: "GET IN."

The boat starts taking speed and it all fades...

TO RED.

~ EndGame("RedEnding")
-> END

=== story

DEATH: "THERE WERE:
{ memory.fire: - OBVIOUSLY A FIRE }
{ memory.meteorite: - SOMETHING LIKE A METEORITE }
{ memory.moon: - PROBABLY NOT THE MOON }
{ memory.helicopter:  - A CRASHING HELICOPTER }
{ memory.children: - CHILDREN IN A LIFE THREATENING SITUATION}"

DEATH: "LET ME HELP YOU."

~ PlaySound("hmm")
The ominous figure took what can only be described as a deep breath, but sounded more like a stone gritting against its tomb.

DEATH: "YOU LEFT WORK AT 6PM. ON YOUR WAY BACK, A HELICOPTER FELL OUT OF THE SKY. IF YOU WEREN'T HERE, A SCHOOL BUS FULL OF CHILDREN WOULD HAVE BEEN CRUSHED."

"Oh. I see. I guess I didn't make it then."

DEATH: "YOU'RE CORRECT. ONCE AGAIN."

"That takes care of the electricity bill I suppose."

DEATH: "HALF FULL GLASS, I LIKE IT. USUALLY MY 'CLIENTS' HAVE 'DIFFICULTIES' TO COME TO TERMS WITH THE SITUATION. WON'T YOU BE MISSED?"

"Not really. No family, only a cat."

DEATH: "A CAT? I LIKE CATS. WHAT IS IT CALLED?"

*   (bland) The Cat.
*   (addiction) Nicotine.
        ~HP1 = HP1 + 10
*   (cute) Meow. 
        ~HP1 = HP1 + 20
-
{
    - bland:
        DEATH: "HOW BASIC."
    - addiction:
        DEATH: "SOUNDS LIKE MY LINE OF WORK."
    - cute:
        DEATH: "UNUSUAL, BUT CUTE."
}

"So, what's next then?"

DEATH: "USUALLY, MY 'CLIENTS' HAVE SOMETHING OF AN EXISTENTIAL CRISIS. I TAKE SOME TIME TO LET THEM THROW A LITTLE TANTRUM AND REASSURE THEM THAT THE WORLD CAN AND WILL CONTINUE WITHOUT THEM. SO WE'RE A BIT AHEAD OF SCHEDULE, YOUR BOAT SHOULD ARRIVE SOON."

"I take it you're Death then."

~ PlayAnimation("DEATH", "Idle")
~ PlaySound("hmm")
DEATH: "ANOTHER FINE OBSERVATION. WHAT TIPPED YOU OFF?" said the otherworldy character slowly turning to face you.

* (scythe) Your scythe, it's SO sharp and shiny! 
    ~HP1 = HP1 + 10
* (eyes) Your eyes, they're SO deep! 
    ~HP1 = HP1 + 20
* (cross) The cross on your cape, even if it's a bit on the nose.
- DEATH: "ERM, THANKS, I THINK."

{ HP1 < 60: -> boat_arrives }

DEATH: "ACTUALLY, I COULD USE SOME COMPANY. CARE TO JOIN ME FOR A RIDE?"

* (inquisitor) "Ride? What kind of a ride?"
* (resolved) "Why not? Eternity can keep waiting."
* (enthusiastic) "Hell yes! Er, pardon my blasphemy."

- ~ PlayAnimation("DEATH", "Back")
    Death snaps two fingers and a loud roar followed by four spinning discs of fire appear out of thin air and stop right at your feet. This car, as you should probably call it, looks like it's made of breathing lava and metal. As it cools down, you begin to distinguish chrome and the hot rod carcass it forms. Fire keeps bursting from its numerous exhaust pipes.

DEATH: "FIRST STOP, OUR NEXT CLIENT."

In what can only be described as the mother of all 'pedals to the metal' (quite litterally in this case), the car takes so much speed that you quickly break the sound barrier soon followed by the visual barrier, transforming the landscape into a kaleidoscope of colours.

Another instant and you feel like your eyes wanting to pop out as Death hits the brakes. You find yourself in a city, but it does not look like your home country. There is no one around and all objects seem to be glued in time and space.

Death heads towards a small silhouette lying on the floor.

~ PlayAnimation("DEATH", "Idle")
DEATH: "THIS LITTLE GIRL HERE DIED FROM SEVERE ASTHMA. SHE WAS RUNNING, TRYING TO ESCAPE THE MERCHANTS FROM WHOM SHE STOLE SOME FOOD. WORST, IT WAS NOT EVEN FOR HER. SHE WAS RUSHING TO THE MAKESHIFT ORPHANAGE TO GIVE IT TO THE BAND SHE FELT SHE WAS IN CHARGE OF."

The little girl gets up, looks around her and starts crying: "What are they going to do without me?"

DEATH: "WHAT WOULD YOU DO?" as they start walking towards the child.

You take some time to think:
* "Can you give her back her life? Poor thing hardly even toddled."
    ~HP2 = HP2 + 30
    "ON RARE OCCASIONS, I MIGHT OVERSTEP A LITTLE. BUT WHAT GOOD COULD IT BRING HER IF SHE GOES BACK?"
 ~ PlayAnimation("DEATH", "Back")
    You see Death whispering something in her ears and taking her up in their arms. They put the little girl on a boat floating on a gravity-defying river and wave as the boat takes her away.
    "What did you say to her?"
    "I TOLD HER THEY WOULD EVENTUALLY BE SAFE."
    "Will they though?"
    "I DON'T KNOW, BUT EVERYONE IS SAFE EVENTUALLY."
* "Well, I can only hope her afterlife will be better than this one."
 ~ PlayAnimation("DEATH", "Back")
    "I REALLY HOPE SO." You see Death whispering something in her ears and taking her up in their arms. They put the little girl on a boat floating on a gravity-defying river and wave as the boat takes her away.
    "What did you say to her?"
    "I TOLD HER THEY WOULD EVENTUALLY BE SAFE."
    "Will they though?"
    "I DON'T KNOW, BUT EVERYONE IS SAFE EVENTUALLY."
* [You run past Death and take the little girl in your arms.]
    Death watches as you run and take the little girl in your arms.
    ~HP2 = HP2 + 50
    DEATH: "WELL, ME NEITHER" as they watch you trying to comfort her.
    "Everything will be okay." You tell the little girl, your eyes begging Death to confirm. "INDEED, EVERYTHING WILL BE Okay." Death's voice seems muffled as they take her up in their arms. They put the little girl on a boat floating on a gravity-defying river and wave as the boat takes her away.

- 
    ~ PlayAnimation("DEATH", "Back")
    DEATH: "ENOUGH NOW, OR WE MIGHT BE LATE." And they snap their fingers again. The car had vanished and does not seem to come back. You look to them as they extend a bonely finger towards the sky. A pegasus made of ice lands in a tornado of snowflakes. You leave the scene in a flash.

You land softly on a skyscraper, on the last floor. A penthouse, ending up in a swimming pool made of glass over the rooftops. At second glance, you noticed how much it is broken and how its lone swimmer is hanging over the edge.

DEATH: "THE PERSON YOU SEE HERE HAS JUMPED STATES TO AVOID EVERY POSSIBLE CONVICTION. YET HE HAS MURDERED PEOPLE, SOLD DRUGS AND WORSE... AND FINALLY, FATE SEEMS TO HAVE CAUGHT BACK TO HIM. WHAT WOULD YOU DO?"
 ~ PlayAnimation("DEATH", "Idle")
* "Earth will probably be better without him."
    ~HP2 = HP2 + 30
    You watch as the fingers give up one after the other. As the silhouette shrinks in the distance a huge red hole opens and swallows it.
    DEATH: "PROBABLY."
* [You come closer and lend a hand]
    You catch the hanging man and helps him back on the roof. He fades rapidly.
    DEATH: "HE WILL CONTINUE HIS EVIL DEEDS."
    "Or not, you never know."
    ~HP2 = HP2 + 50
* [You come closer and stomps your foot on his fingers.]
    The man falls. As the silhouette shrinks in the distance a huge red hole opens and swallows it.
    DEATH: "THAT WAS NOT NECESSARY."
    "He deserved it."
    DEATH: "IT SEEMS SO, BUT HE WOULD HAVE FALLEN EVENTUALLY."

{ HP2 < 60: -> boat_arrives }

 ~ PlayAnimation("DEATH", "Back")
- "WE MIGHT HAVE SOME TIME LEFT. WOULD YOU CARE TO JOIN ME FOR LUNCH?"

TO BE CONTINUED...
~ EndGame("BlueEnding")

-> END

=== boat_arrives ===
DEATH: "IT LOOKS LIKE YOUR TIME HAS COME. HAVE A NICE AFTERLIFE, I GUESS..."

Death extends a bonely hand and helps you abord a boat floating on what seems to be a gravity-defying river.

The boat starts taking speed and it all begins to fade...

TO WHITE.
~ EndGame("WhiteEnding")

-> END