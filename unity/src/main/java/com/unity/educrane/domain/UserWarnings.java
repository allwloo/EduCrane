package com.unity.educrane.domain;

public class UserWarnings {
	
	private String clientID;
	private int warningID;
	
	public String getClientID() {
		return clientID;
	}
	public void setClientID(String clientID) {
		this.clientID = clientID;
	}
	public int getWarningID() {
		return warningID;
	}
	public void setWarningID(int warningID) {
		this.warningID = warningID;
	}
	
	
	
	
	public UserWarnings(String clientID, int warningID) {
		super();
		this.clientID = clientID;
		this.warningID = warningID;
	}
	public UserWarnings() {
		super();
		// TODO Auto-generated constructor stub
	}
	
	
	@Override
	public String toString() {
		return "UserWarnings [clientID=" + clientID + ", warningID=" + warningID + "]";
	}
	
	

}
