package com.unity.educrane.model.impl;

import java.util.List;

import org.apache.ibatis.session.SqlSession;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.unity.educrane.domain.Setting;
import com.unity.educrane.domain.User;
import com.unity.educrane.domain.UserWarnings;
import com.unity.educrane.domain.Warning;
import com.unity.educrane.model.SettingDAO;
import com.unity.educrane.model.UserDAO;
import com.unity.educrane.model.WarningDAO;

@Repository
public class WarningDAOImpl implements WarningDAO {
	
	@Autowired
	private SqlSession sqlSession;

	@Override
	public List<Object> getWarning(String id) {
		return null;
	}
	
	
	
	

}
