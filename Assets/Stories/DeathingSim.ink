# theme: dark
# author: Hadrien Debris
VAR HP1 = 0
VAR HP2 = 0
VAR HP3 = 0
VAR HP4 = 0
VAR HP5 = 0
VAR CNAME = ""

-> DEATH

=== DEATH ===

This morning, opening your eyes seems easier than usual, as if your eyelids were lighter. However, your head feels fuzzy. You probably overslept, needing some time to recollect your spirits but at least you are feeling refreshed. 

You rapidly understand that you are not home anymore.

You keep blinking as the landscape before you does not seem to stop changing.

A tall figure stands beside you seemingly oblivious to the large fire a few feet away.

~CNAME = "DEATH"

DEATH: "ARE YOU OK?"
    * [Nod]
        ~CNAME = ""
        You acknowledge faintly.
    * "Probably..."
        The silhouette gives you time to gather your thoughts.
    * "I'm not so sure."
        The silhouette seems to understand your situation.

-   DEATH: "WHAT IS THE LAST THING YOU REMEMBER?"
Staring at the fire, you begin to remember a few things.  -> memory

=== memory ===
    *   (fire) "There was a fire."
        // I THINK I CAN SEE WHERE \*THAT'S\* COMING FROM.
        DEATH: THAT'S ON ME. STARTING SLOW. AT LEAST I CAN SEE THAT YOU'RE DEMONSTRATING BASIC VISUAL ACUITY. 
        -> memory
    *   (children) "There were... children?"
        DEATH: WHAT ABOUT THEM?
            * * "Are they safe?" 
                DEATH: WELL, THEY ARE NOW. 
                -> memory
            * * "They were in danger." 
                DEATH: NOT ANYMORE. 
                -> memory
            * * "I hurt them." 
                -> hurt
    *   (object) "There was something falling from the sky!"
        DEATH: "WHAT WAS IT?"
            * * (meteorite) "A giant ball of fire."
                DEATH: CLOSE ENOUGH. 
                -> memory
            * * (moon) "The Moon!"
                DEATH: AREN'T YOU A BIT OVER DRAMATIC? 
                -> memory
            * * (helicopter) "It looked like... People screaming?"
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

DEATH: TO RED. -> END

=== story

DEATH: "THERE WERE:
{ memory.fire: - OBVIOUSLY A FIRE }
{ memory.meteorite: - SOMETHING LIKE A METEORITE }
{ memory.moon: - PROBABLY NOT THE MOON }
{ memory.helicopter:  - A CRASHING HELICOPTER }
{ memory.children: - CHILDREN IN A LIFE THREATENING SITUATION}"

DEATH: "LET ME HELP YOU."

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
*   (cute) Meow.
-
{
    - bland:
        DEATH: "HOW BASIC."
    - addiction:
        DEATH: "SOUNDS LIKE MY LINE OF WORK."
    - cute:
        DEATH: "UNUSUAL, BUT CUTE."
}


-> END

The character helps you abord the embarcation.

DEATH: "WELL ACTUALLY, MY NAME IS DEATH... BUT YOU PROBABLY FIGURED THAT OUT ALREADY. 
WOULD YOU SPARE A FEW MOMENTS TO HELP ME VENT ABOUT MY DAY?"

-> END