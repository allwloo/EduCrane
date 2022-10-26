package com.unity.educrane.model.impl;

import java.util.List;

import org.apache.ibatis.session.SqlSession;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.unity.educrane.domain.Setting;
import com.unity.educrane.domain.User;
import com.unity.educrane.domain.UserWarnings;
import com.unity.educrane.domain.Warning;
import com.unity.educrane.model.UserDAO;

@Repository
public class UserDAOImpl implements UserDAO {
	
	@Autowired
	private SqlSession sqlSession;

	@Override
	public User getUserByID(String id) {
		System.out.println("DAO::: getUserByID start...");
		
		return sqlSession.selectOne("sql.unity.mapper.getUserByID",id);
	}
	
	@Override
	public Setting getSetting(String id) {
		System.out.println("DAO:: getSetting start...");
		
		return sqlSession.selectOne("sql.unity.mapper.getSetting", id);
	}

	@Override
	public List<Object> getWarning(String id) {
		// TODO Auto-generated method stub
		
		return sqlSession.selectList("sql.unity.mapper.getUserWarnings", id);
	}
	
	

}
