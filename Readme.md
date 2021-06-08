# 飞机大战
-------
## 游戏简介

2D 弹幕射击游戏， 主要以子弹击败敌人获得道具获得分数为主

## 模块设计


### Unit角色模块
- Player： 
  1. 控制：WASD移动， fire1开火， space技能 
- Enemy： 
  1. 控制： 简单的向前移动
  2. 类型： 普通敌人， 上下摇摆敌人， 速度很快的敌人
- Boss:
  1. 控制： 定时上下移动
  2. 开火： fire1 普通开火， fire2 定位炮台攻击， fire3 导弹追踪
- Delivery(类似道具空投)
  1. 控制： 随机下落
  2. 功能： 击杀掉落道具

### Item道具模块
- Item
  1. 实现道具的初始化， 开放use道具使用函数
- Apple
  1. 功能：恢复hp
- Gold
  1. 功能：购买商店物品（未实现）

### Elements 子弹模块
- Bullet
  1. 普通子弹的实现
- Misslie
  1. 跟踪导弹，以及主角技能

### UI模块
- player HP条
- gold 金币数
- score 击杀分数
- Level 关卡名字显示
- UIAnimation 简单的关卡进入动画
- atuomic 角色大招数量显示

### LevelManager
- SpawnRule  配置生成敌人
- DeliveryRule 配置生成空投
- Level 生成关底boss，控制关卡开始结束

### PoolManager
- 实现prefab加载

### AnimationManager模块
- 实践策略模式， 便捷调用对应的动画

### Utility
- Singleton 单例实现
- ViewPoint 主角控制在主屏幕内
- DeActive 时间延时
