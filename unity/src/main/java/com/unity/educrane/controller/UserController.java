package com.unity.educrane.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import com.unity.educrane.domain.Setting;
import com.unity.educrane.domain.User;
import com.unity.educrane.model.SettingDAO;
import com.unity.educrane.model.UserDAO;
import com.unity.educrane.model.WarningDAO;

@Controller
public class UserController {
	
	@Autowired
	private UserDAO userDAO;
	@Autowired
	private SettingDAO settingDAO;
	@Autowired
	private WarningDAO warningDAO;
	
	@RequestMapping("userInfo.do")
	@ResponseBody
	public User getUser(String id) {
		return userDAO.getUserByID(id);
	}
	
	@RequestMapping("warning.do")
	@ResponseBody
	public List<Object> getWarnings(String id) {
		System.out.println("Controller::: warning.do start....");
		
		return warningDAO.getWarning(id);
	}
	
	@RequestMapping("setting.do")
	@ResponseBody
	public Setting getSetting(String id) {
		System.out.println("Controller::: setting.do start....");
		
		return settingDAO.getSetting(id);
	}
	
	@RequestMapping("changeSetting.do")
	@ResponseBody
	public int changeSetting(Setting setting) {
		System.out.println("Controller::: changeSetting.do");
		
		return settingDAO.changeSetting(setting);
	}

}

