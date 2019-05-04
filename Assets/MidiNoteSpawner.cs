using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Smf.Interaction;

public class MidiNoteSpawner : MonoBehaviour
{
    public TextAsset midiFile;
    public GameObject prefab;

    private Transform noteParent;
    private SevenBitNumber minPitch = SevenBitNumber.MaxValue;
    private SevenBitNumber maxPitch = SevenBitNumber.MinValue;

    public float lengthScaler = 1.8f;
    public float xOffset = 1;
    public float yOffset = 1;
    void Start()
    {
        this.noteParent = new GameObject("Notes").transform;

        if (this.midiFile == null)
        {
            Debug.Log("No Midi file specified");
            return;
        }

        var midi = LoadMidi(this.midiFile.bytes);


        foreach (var channel in midi)
        {
            foreach (var note in channel)
            {
                CreateNote(note.Time * lengthScaler, note.NoteNumber, note.Length * lengthScaler);
            }
        }
    }

    IEnumerable<NotesCollection> LoadMidi(byte[] bytes)
    {
        Stream stream = new MemoryStream(bytes);
        MidiFile file = MidiFile.Read(stream);
        var midi = file.GetTrackChunks().Select(track => track.ManageNotes().Notes);

        minPitch = SevenBitNumber.MaxValue;
        maxPitch = SevenBitNumber.MinValue;
        foreach (var channel in midi)
        {
            foreach (var note in channel)
            {
                if (note.NoteNumber < minPitch) minPitch = note.NoteNumber;
                if (note.NoteNumber > maxPitch) maxPitch = note.NoteNumber;
            }
        }

        return midi;
    }

    void CreateNote(float time, int pitch, float length)
    {
        float noteLength = length / 350f;
        GameObject note = Instantiate(prefab, noteParent);
        var midiNote = note.GetComponent<MidiNote>();
        midiNote.length = noteLength;
        note.transform.position = new Vector3(
            (float)((time / 2000d) + xOffset),
            (((pitch - minPitch) / (float)(maxPitch - minPitch) * 4 - 2) * 1.2f) + yOffset,
            1
        );

    }

    // Update is called once per frame
    void Update()
    {

    }
}
