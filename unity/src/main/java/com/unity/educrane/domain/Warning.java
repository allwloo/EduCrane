package com.unity.educrane.domain;

public class Warning {
	
	private int warningID;
	private String message;
	private int risk;
	
	
	
	public Warning() {
		super();
	}


	public Warning(int warningID, String message, int risk) {
		super();
		this.warningID = warningID;
		this.message = message;
		this.risk = risk;
	}


	@Override
	public String toString() {
		return "Warning [warningID=" + warningID + ", message=" + message + ", risk=" + risk + "]";
	}


	public int getWarningID() {
		return warningID;
	}


	public void setWarningID(int warningID) {
		this.warningID = warningID;
	}


	public String getMessage() {
		return message;
	}


	public void setMessage(String message) {
		this.message = message;
	}


	public int getRisk() {
		return risk;
	}


	public void setRisk(int risk) {
		this.risk = risk;
	}
	
	

}
