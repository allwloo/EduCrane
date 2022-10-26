package com.unity.educrane.domain;

public class User {
	
	private String clientID;
	private int userLevel;
	private double lotateX;
	private double lotateY;
	private double lotateZ;
	private String exitTime;
	private int finTimes;
	private Lotation lotation;
	private Setting setting;
	private Warning warning;
	
	
	
	@Override
	public String toString() {
		return "User [clientId=" + clientID + ", level=" + userLevel + ", lotateX=" + lotateX + ", lotateY=" + lotateY
				+ ", lotateZ=" + lotateZ + ", exitTime=" + exitTime + ", finTimes=" + finTimes + ", lotation="
				+ lotation + ", setting=" + setting + ", warning=" + warning + "]";
	}
	public User() {
		super();
	}
	public User(String clientId, int level, double lotateX, double lotateY, double lotateZ, String exitTime,
			int finTimes, Lotation lotation, Setting setting, Warning warning) {
		super();
		this.clientID = clientId;
		this.userLevel = level;
		this.lotateX = lotateX;
		this.lotateY = lotateY;
		this.lotateZ = lotateZ;
		this.exitTime = exitTime;
		this.finTimes = finTimes;
		this.lotation = lotation;
		this.setting = setting;
		this.warning = warning;
	}
	public String getClientId() {
		return clientID;
	}
	public void setClientId(String clientId) {
		this.clientID = clientId;
	}
	public int getLevel() {
		return userLevel;
	}
	public void setLevel(int level) {
		this.userLevel = level;
	}
	public double getLotateX() {
		return lotateX;
	}
	public void setLotateX(double lotateX) {
		this.lotateX = lotateX;
	}
	public double getLotateY() {
		return lotateY;
	}
	public void setLotateY(double lotateY) {
		this.lotateY = lotateY;
	}
	public double getLotateZ() {
		return lotateZ;
	}
	public void setLotateZ(double lotateZ) {
		this.lotateZ = lotateZ;
	}
	public String getExitTime() {
		return exitTime;
	}
	public void setExitTime(String exitTime) {
		this.exitTime = exitTime;
	}
	public int getFinTimes() {
		return finTimes;
	}
	public void setFinTimes(int finTimes) {
		this.finTimes = finTimes;
	}
	public Lotation getLotation() {
		return lotation;
	}
	public void setLotation(Lotation lotation) {
		this.lotation = lotation;
	}
	public Setting getSetting() {
		return setting;
	}
	public void setSetting(Setting setting) {
		this.setting = setting;
	}
	public Warning getWarning() {
		return warning;
	}
	public void setWarning(Warning warning) {
		this.warning = warning;
	}
	
	

}
