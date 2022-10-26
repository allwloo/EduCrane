package com.unity.educrane.domain;

public class Setting {
	
	private int voiceType;
	private int isSignalman;
	private int effectSound;
	private int backSound;
	
	
	
	
	@Override
	public String toString() {
		return "Setting [voiceType=" + voiceType + ", isSignalman=" + isSignalman + ", effectSound=" + effectSound
				+ ", backSound=" + backSound + "]";
	}

	public Setting() {
		super();
	}
	
	public Setting(int voiceType, int isSignalman, int effectSound, int backSound) {
		super();
		this.voiceType = voiceType;
		this.isSignalman = isSignalman;
		this.effectSound = effectSound;
		this.backSound = backSound;
	}
	public int getVoiceType() {
		return voiceType;
	}
	public void setVoiceType(int voiceType) {
		this.voiceType = voiceType;
	}
	public int getIsSignalman() {
		return isSignalman;
	}
	public void setIsSignalman(int isSignalman) {
		this.isSignalman = isSignalman;
	}
	public int getEffectSound() {
		return effectSound;
	}
	public void setEffectSound(int effectSound) {
		this.effectSound = effectSound;
	}
	public int getBackSound() {
		return backSound;
	}
	public void setBackSound(int backSound) {
		this.backSound = backSound;
	}
	
	
	
	

}
