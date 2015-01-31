using System;
using AVFoundation;

[assembly: Xamarin.Forms.Dependency (typeof (TextToSpeech_iOS))]

public class TextToSpeech_iOS : MobileCRM.ITextToSpeech
{
	public TextToSpeech_iOS () {}

	public void Speak (string text)
	{
		var speechSynthesizer = new AVSpeechSynthesizer ();

		var speechUtterance = new AVSpeechUtterance (text) {
			Rate = AVSpeechUtterance.MaximumSpeechRate/4,
			Voice = AVSpeechSynthesisVoice.FromLanguage ("en-US"),
			Volume = 0.5f,
			PitchMultiplier = 1.0f
		};

		speechSynthesizer.SpeakUtterance (speechUtterance);
	}
}