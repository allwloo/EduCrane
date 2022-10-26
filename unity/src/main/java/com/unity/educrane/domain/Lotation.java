package com.unity.educrane.domain;

public class Lotation {
	
	private String lotationID;
	private String address;
	private String lotationName;
	private int lotationType;
	
	
	public Lotation() {
		super();
	}
	
	public Lotation(String lotationID, String address, String lotationName, int lotationType) {
		super();
		this.lotationID = lotationID;
		this.address = address;
		this.lotationName = lotationName;
		this.lotationType = lotationType;
	}
	
	@Override
	public String toString() {
		return "Lotation [lotationID=" + lotationID + ", address=" + address + ", lotationName=" + lotationName
				+ ", lotationType=" + lotationType + "]";
	}
	public String getLotationID() {
		return lotationID;
	}
	public void setLotationID(String lotationID) {
		this.lotationID = lotationID;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	public String getLotationName() {
		return lotationName;
	}
	public void setLotationName(String lotationName) {
		this.lotationName = lotationName;
	}
	public int getLotationType() {
		return lotationType;
	}
	public void setLotationType(int lotationType) {
		this.lotationType = lotationType;
	}
	
	
	
}
