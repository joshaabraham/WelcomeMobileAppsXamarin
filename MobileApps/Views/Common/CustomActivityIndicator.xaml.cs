using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileApps
{
	public partial class CustomActivityIndicator : ContentView
	{
		private bool _playing = false;
		private Animation _animation;

		public CustomActivityIndicator()
		{
			InitializeComponent();
		}

		public void Start()
		{
			_animation = new Animation(
				callback: d => Wrapper.RotationY = d,
				start: 0,
				end: 360,
				easing: Easing.Linear);

			_playing = true;
			_animation.Commit(Wrapper, "Loop", length: 1000, repeat: () => _playing);
		}

		public void Stop()
		{
			_playing = false;
			_animation = null;
		}
	}
}

