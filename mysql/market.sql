/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 80021
 Source Host           : localhost:3306
 Source Schema         : market

 Target Server Type    : MySQL
 Target Server Version : 80021
 File Encoding         : 65001

 Date: 31/12/2020 12:05:37
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for admin
-- ----------------------------
DROP TABLE IF EXISTS `admin`;
CREATE TABLE `admin`  (
  `uid` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `uname` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `upsw` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `uage` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of admin
-- ----------------------------
INSERT INTO `admin` VALUES ('0001', '张三', '0001', '18');
INSERT INTO `admin` VALUES ('admin', 'admin', 'admin', '20');

-- ----------------------------
-- Table structure for admin_copy1
-- ----------------------------
DROP TABLE IF EXISTS `admin_copy1`;
CREATE TABLE `admin_copy1`  (
  `uid` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `uname` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `upsw` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `uage` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of admin_copy1
-- ----------------------------

-- ----------------------------
-- Table structure for buyorder
-- ----------------------------
DROP TABLE IF EXISTS `buyorder`;
CREATE TABLE `buyorder`  (
  `uid` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `gid` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `date` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`uid`, `gid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of buyorder
-- ----------------------------

-- ----------------------------
-- Table structure for buyrecode
-- ----------------------------
DROP TABLE IF EXISTS `buyrecode`;
CREATE TABLE `buyrecode`  (
  `uid` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `gid` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `gprice` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `date` datetime(0) NOT NULL,
  PRIMARY KEY (`date`) USING BTREE,
  INDEX `uid`(`uid`) USING BTREE,
  INDEX `gid1`(`gid`) USING BTREE,
  CONSTRAINT `gid1` FOREIGN KEY (`gid`) REFERENCES `goods` (`gid`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `uid` FOREIGN KEY (`uid`) REFERENCES `user` (`uid`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of buyrecode
-- ----------------------------
INSERT INTO `buyrecode` VALUES ('1002', '1001', '12', '2020-12-30 23:40:09');
INSERT INTO `buyrecode` VALUES ('user', '1001', '12', '2020-12-31 11:42:27');

-- ----------------------------
-- Table structure for goods
-- ----------------------------
DROP TABLE IF EXISTS `goods`;
CREATE TABLE `goods`  (
  `gid` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `gname` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `gcost` double(10, 2) NULL DEFAULT NULL,
  `gmount` int NULL DEFAULT NULL,
  `gfirm` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`gid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of goods
-- ----------------------------
INSERT INTO `goods` VALUES ('1001', '火鸡面', 12.00, 95, '111');

-- ----------------------------
-- Table structure for orders
-- ----------------------------
DROP TABLE IF EXISTS `orders`;
CREATE TABLE `orders`  (
  `orderid` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ocost` double(10, 2) NULL DEFAULT NULL,
  `opost` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `date` datetime(0) NULL DEFAULT NULL,
  `gid` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`orderid`) USING BTREE,
  INDEX `gid`(`gid`) USING BTREE,
  CONSTRAINT `gid` FOREIGN KEY (`gid`) REFERENCES `goods` (`gid`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of orders
-- ----------------------------

-- ----------------------------
-- Table structure for sale
-- ----------------------------
DROP TABLE IF EXISTS `sale`;
CREATE TABLE `sale`  (
  `sid` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `gid` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `gname` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `sprice` double(10, 2) NULL DEFAULT NULL,
  `date` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`sid`) USING BTREE,
  INDEX `sid`(`gid`) USING BTREE,
  CONSTRAINT `sid` FOREIGN KEY (`gid`) REFERENCES `goods` (`gid`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sale
-- ----------------------------
INSERT INTO `sale` VALUES ('2020123023376', '1001', '火鸡面', 12.00, '2020/12/30 23:37:06');
INSERT INTO `sale` VALUES ('2020123023409', '1001', '火鸡面', 12.00, '2020/12/30 23:40:09');
INSERT INTO `sale` VALUES ('20201231114227', '1001', '火鸡面', 12.00, '2020/12/31 11:42:27');

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `uid` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `uname` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `upsw` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `uage` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `balance` double(25, 2) NULL DEFAULT NULL,
  PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('1002', '1002', '1002', '56', 32.00);
INSERT INTO `user` VALUES ('123', '123', '123', '123', 123.00);
INSERT INTO `user` VALUES ('78', '45', '23', '45', 56.00);
INSERT INTO `user` VALUES ('user', 'user', 'user', '20', 99988.00);

-- ----------------------------
-- View structure for adminv
-- ----------------------------
DROP VIEW IF EXISTS `adminv`;
CREATE ALGORITHM = UNDEFINED SQL SECURITY DEFINER VIEW `adminv` AS select `admin`.`uid` AS `uid`,`admin`.`uname` AS `uname`,`admin`.`upsw` AS `upsw`,`admin`.`uage` AS `uage` from `admin`;

-- ----------------------------
-- View structure for buyorderv
-- ----------------------------
DROP VIEW IF EXISTS `buyorderv`;
CREATE ALGORITHM = UNDEFINED SQL SECURITY DEFINER VIEW `buyorderv` AS select `buyorder`.`uid` AS `uid`,`buyorder`.`gid` AS `gid`,`buyorder`.`date` AS `date` from `buyorder`;

-- ----------------------------
-- View structure for buyrecodev
-- ----------------------------
DROP VIEW IF EXISTS `buyrecodev`;
CREATE ALGORITHM = UNDEFINED SQL SECURITY DEFINER VIEW `buyrecodev` AS select `buyrecode`.`uid` AS `uid`,`buyrecode`.`gid` AS `gid`,`buyrecode`.`gprice` AS `gprice`,`buyrecode`.`date` AS `date` from `buyrecode`;

-- ----------------------------
-- View structure for goodsv
-- ----------------------------
DROP VIEW IF EXISTS `goodsv`;
CREATE ALGORITHM = UNDEFINED SQL SECURITY DEFINER VIEW `goodsv` AS select `goods`.`gid` AS `gid`,`goods`.`gname` AS `gname`,`goods`.`gcost` AS `gcost`,`goods`.`gmount` AS `gmount`,`goods`.`gfirm` AS `gfirm` from `goods`;

-- ----------------------------
-- View structure for ordersv
-- ----------------------------
DROP VIEW IF EXISTS `ordersv`;
CREATE ALGORITHM = UNDEFINED SQL SECURITY DEFINER VIEW `ordersv` AS select `orders`.`orderid` AS `orderid`,`orders`.`ocost` AS `ocost`,`orders`.`opost` AS `opost`,`orders`.`date` AS `date`,`orders`.`gid` AS `gid` from `orders`;

-- ----------------------------
-- View structure for salev
-- ----------------------------
DROP VIEW IF EXISTS `salev`;
CREATE ALGORITHM = UNDEFINED SQL SECURITY DEFINER VIEW `salev` AS select `sale`.`sid` AS `sid`,`sale`.`gid` AS `gid`,`sale`.`gname` AS `gname`,`sale`.`sprice` AS `sprice`,`sale`.`date` AS `date` from `sale`;

-- ----------------------------
-- View structure for userv
-- ----------------------------
DROP VIEW IF EXISTS `userv`;
CREATE ALGORITHM = UNDEFINED SQL SECURITY DEFINER VIEW `userv` AS select `user`.`uid` AS `uid`,`user`.`uname` AS `uname`,`user`.`upsw` AS `upsw`,`user`.`uage` AS `uage`,`user`.`balance` AS `balance` from `user`;

SET FOREIGN_KEY_CHECKS = 1;
