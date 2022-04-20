//
// Created by gama on 31.03.22.
//
#include "gtest/gtest.h"
#include "../src/parsers/QDBAPIParser.h"


TEST(QDBAPIParserTest, parseNumberOfColumn) {
    parser::QDBAPIParser parser;
    EXPECT_EQ(1,parser.parseNumberOfColumn("{\"query\":\"select id from Container where id = 'questdb\\/questdb:latest'\",\"columns\":[{\"name\":\"id\",\"type\":\"SYMBOL\"}],\"dataset\":[[\"questdb\\/questdb:latest\"]],\"count\":1}"));
}
TEST(QDBAPIParserTest, checkForError) {
    parser::QDBAPIParser parser;
    EXPECT_EQ(false, parser.checkForError("{\"query\":\"select id from Container limit 1\",\"columns\":[{\"name\":\"id\",\"type\":\"SYMBOL\"}],\"dataset\":[[\"data_collector\"]],\"count\":1}"));
    EXPECT_EQ(true, parser.checkForError("{\"query\":\"select * from CCC\",\"columns\":[{\"name\":\"id\",\"type\":\"SYMBOL\"}],\"dataset\":[[\"data_collector\"]],\"count\":0 , \"error\":\"table with name CCC not found\"}"));
}