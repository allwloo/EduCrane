package com.unity.educrane.model;

import java.util.List;

import org.apache.ibatis.session.SqlSession;
import org.springframework.beans.factory.annotation.Autowired;

import com.unity.educrane.domain.Setting;
import com.unity.educrane.domain.User;
import com.unity.educrane.domain.UserWarnings;
import com.unity.educrane.domain.Warning;

public interface UserDAO {
	
	
	public User getUserByID(String id);
	public Setting getSetting(String id);
	public List<Object> getWarning(String id);

}
