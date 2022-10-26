package com.unity.educrane.model;

import com.unity.educrane.domain.Setting;

public interface SettingDAO {

	public Setting getSetting(String id);
	public int changeSetting(Setting setting);

}
