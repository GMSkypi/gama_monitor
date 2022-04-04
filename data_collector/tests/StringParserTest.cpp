//
// Created by gama on 31.03.22.
//
#include "gtest/gtest.h"
#include "../src/parsers/StringParser.h"

TEST(GetUnsignedFromStringTest, SmallNumberTest) {
    EXPECT_EQ( 123, parser::getUnsignedFromString("123"));
}
TEST(GetUnsignedFromStringTest, BigNumberTest) {
    EXPECT_EQ( 0, parser::getUnsignedFromString("12315644531584163845"));
}

TEST(tokenize, newLineTest) {
    vector<string> tokens = parser::tokenize("user 1564165\nkernel 57648",regex("\\n"));
    ASSERT_EQ(2, tokens.size());
    EXPECT_EQ("user 1564165", tokens[0]);
    EXPECT_EQ("kernel 57648", tokens[1]);
}
TEST(tokenize, stringSplitTest) {
    vector<string> tokens = parser::tokenize("user 1564165\nkernel 57648",regex("\\D+"));
    ASSERT_EQ(2, tokens.size());
    EXPECT_EQ("1564165", tokens[0]);
    EXPECT_EQ("57648", tokens[1]);
}

TEST(firstMatchRegex, TestName) {
    string match = parser::firstMatchRegex("Read 1564165\n Write 48645", regex("(Read )[0-9]*"));
    EXPECT_EQ("Read 1564165", match);
}
