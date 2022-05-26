# theme: dark
# author: Hadrien Debris

-> DEATH

=== DEATH ===

This morning, opening your eyes seems easier than usual, as if your eyelids were lighter. However, your head feels fuzzy. You probably overslept, needing some time to recollect your spirits but at least you are feeling refreshed. 

You rapidly understand that you are not home anymore.

You keep blinking as the landscape before you does not seem to stop changing.

A tall figure stands beside you seemingly oblivious to the large fire a few feet away.

"ARE YOU OK?"
    * [Nod]
        You acknowledge faintly.
    * "Probably..."
        The silhouette gives you time to gather your thoughts.
    * "I'm not so sure."
        The silhouette seems to understand your situation.

-   "WHAT IS THE LAST THING YOU REMEMBER?"
Staring at the fire, you begin to remember a few things.  -> memory

=== memory ===
    *   "There was a fire."
        I THINK I CAN SEE WHERE \*THAT'S\* COMING FROM. -> memory
    *   (children) "There were... children?"
        WHAT ABOUT THEM?
            * * "Are they safe?" 
                WELL, THEY ARE NOW. -> memory
            * * "They were in danger." 
                NOT ANYMORE. -> memory
            * * "I hurt them." -> memory_failed
    *   (object) "There was something falling from the sky!"
        WHAT WAS IT?
            * * (meteorit) "A giant ball of fire."
                CLOSE ENOUGH. -> memory
            * * (moon) "The Moon!"
                AREN'T YOU A BIT OVER DRAMATIC? -> memory
            * * (helicopter) "It looked like... People screaming?"
                INDEED. -> memory
    * { children } { object } ->
        LET ME SUM UP. 
        -> to_be_continued

-> memory

=== saved ===

    (saved) YES. YOU SAVED THEM. -> memory

=== hurt ===

    (hurt) YOU'RE RIGHT. -> memory_failed

=== memory_failed ===

The silhouette points a bonely finger at a boat floating on what seemed to be a gravity-defying river.

"GET IN."

The boat starts taking speed and it all fades...

TO RED. -> END

=== to_be_continued ===

To be continued... -> END

-> END