﻿using System;
using System.Collections.Generic;

namespace Syntage.Framework.Tools
{
	public static class DSPFunctions
	{
		public const double Pi2 = 2 * Math.PI;
		public static readonly double KMinADb = -80;
		public static readonly double KMaxADb = 0;
		public static readonly double KMinA = DbToAmplitude(KMinADb);
		public static readonly double KMaxA = DbToAmplitude(KMaxADb);

		public static double Lerp(double a, double b, double t)
		{
			return a + (b - a) * t;
		}

		public static double Clamp(double t, double min, double max)
		{
			if (t < min) return min;
			if (t > max) return max;
			return t;
		}

		public static double Clamp01(double t)
		{
			return Clamp(t, 0, 1);
		}

		public static double Clamp0Db(double t)
		{
			return Clamp(t, -1, 1);
		}

		public static double AmplitudeToDb(double a)
		{
			a = Clamp(a, KMinA, KMaxA);
			return 20f * Math.Log10(a);
		}

		public static double DbToAmplitude(double db)
		{
			db = Clamp(db, KMinADb, KMaxADb);
			return Math.Pow(10, db / 20.0);
		}
        
        public static double GetNoteFrequency(double note)
        {
            var r = 440 * Math.Pow(2, (note - 69) / 12.0);
            return r;
        }

        public static bool IsZero(double value)
	    {
	        return Math.Abs(value) < 0.001;
	    }

	    public static double Frac(double x)
	    {
	        return x - (int)x;
	    }

        public static List<string> NoteNames = new List<string> {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "H"};

		public static string ToNoteName(int note)
		{
			return NoteNames[note];
		}
	}
}
