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

@Repository
public class SettingDAOImpl implements SettingDAO {
	
	@Autowired
	private SqlSession sqlSession;
	
	@Override
	public Setting getSetting(String id) {
		System.out.println("DAO:: getSetting start...");
		
		return sqlSession.selectOne("sql.unity.mapper.getSetting", id);
	}

	@Override
	public int changeSetting(Setting setting) {
		System.out.println("DAO:: changeSetting start...");
		
		return sqlSession.update("sql.unity.mapper.changeSetting", setting);
	}
	

}
