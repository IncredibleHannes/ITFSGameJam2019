using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;

public class MidiParser : MonoBehaviour
{
    public TextAsset midiFile;

    void Start()
    {
        if (this.midiFile != null) {
            ParseMidi(this.midiFile.bytes);
        } else {
            Debug.Log("No Midi file specified");
        }
    }

    static void ParseMidi(byte[] raw)
    {
        Stream stream = new MemoryStream(raw);
        MidiFile file = MidiFile.Read(stream);

        var channels = file.GetTrackChunks().Select(track => track.ManageNotes().Notes);
        Debug.Log("There are " + channels.Count() + " Channels available");
        foreach (var notes in channels) {
            if (notes.Count() == 0) continue;
            Debug.Log("There are " + notes.Count() + " notes on this channel:");
            string sequence = "";
            foreach (var note in notes) {
                if (sequence.Length != 0) {
                    sequence += ", ";
                }
                sequence += note.NoteNumber + "(" + note.Time + ", " + note.Length + ")";
            }
            Debug.Log(sequence);
        }
    }
}
